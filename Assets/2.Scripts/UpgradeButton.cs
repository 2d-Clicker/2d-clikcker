using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class UpgradeButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public string upgradeName;  // ���׷��̵� �̸�
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI costText;
    public Button upgradeButton;

    private bool isPressing = false; // ��ư�� ������ �ִ��� ����
    private Coroutine upgradeCoroutine; // ���� ���׷��̵�� �ڷ�ƾ

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
            Debug.LogWarning($"���� �ȉ�");
        }
    }

    // ��ư�� �� ������ ���׷��̵� ���� ����
    public void OnPointerDown(PointerEventData eventData)
    {
        if (upgradeCoroutine == null) 
        {
            isPressing = true;
            upgradeCoroutine = StartCoroutine(ContinuousUpgrade());
        }
    }

    // ��ư���� ���� ���� ���׷��̵� ����
    public void OnPointerUp(PointerEventData eventData)
    {
        isPressing = false;
        if (upgradeCoroutine != null)
        {
            StopCoroutine(upgradeCoroutine);
            upgradeCoroutine = null;
        }
    }

    // 0.2�� �������� ���׷��̵� ����
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
