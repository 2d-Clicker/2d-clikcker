using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class UpgradeButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public string upgradeName;  // 업그레이드 이름
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI costText;
    public Button upgradeButton;

    private bool isPressing = false; // 버튼을 누르고 있는지 여부
    private Coroutine upgradeCoroutine; // 연속 업그레이드용 코루틴

    void Start()
    {
        UpdateUI();
        upgradeButton.onClick.AddListener(OnUpgradeClick);
    }

    void UpdateUI()
    {
        int level = UpgradeManager.Instance.GetUpgradeLevel(upgradeName);
        UpgradeData upgrade = UpgradeManager.Instance.upgradeList.Find(u => u.upgradeName == upgradeName);

        int upgradeCost = upgrade.GetUpgradeCost(level);
        int playerGold = UpgradeManager.Instance.playerGold;

        levelText.text = $"{level}";
        costText.text = upgradeCost.ToString();

        costText.color = (playerGold >= upgradeCost) ? Color.black : Color.red;
        upgradeButton.interactable = playerGold >= upgradeCost;
    }

    void OnUpgradeClick()
    {
        if (UpgradeManager.Instance.TryUpgrade(upgradeName))
        {
            UpdateUI();
            UpgradeManager.Instance.UpdateGoldUI();
        }
        else
        {
            Debug.LogWarning($"ㄴㄴ 안됌");
        }
    }

    // 버튼을 꾹 누르면 업그레이드 연속 실행
    public void OnPointerDown(PointerEventData eventData)
    {
        if (upgradeCoroutine == null) 
        {
            isPressing = true;
            upgradeCoroutine = StartCoroutine(ContinuousUpgrade());
        }
    }

    // 버튼에서 손을 떼면 업그레이드 중지
    public void OnPointerUp(PointerEventData eventData)
    {
        isPressing = false;
        if (upgradeCoroutine != null)
        {
            StopCoroutine(upgradeCoroutine);
            upgradeCoroutine = null;
        }
    }

    // 0.2초 간격으로 업그레이드 실행
    IEnumerator ContinuousUpgrade()
    {
        yield return new WaitForSeconds(0.2f); 
        while (isPressing)
        {
            OnUpgradeClick(); 
            yield return new WaitForSeconds(0.2f); 
        }
    }
}
