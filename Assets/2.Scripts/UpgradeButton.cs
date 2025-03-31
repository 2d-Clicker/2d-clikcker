using TMPro;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
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

   
}