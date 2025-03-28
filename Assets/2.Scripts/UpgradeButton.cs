using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    public string upgradeName;  // ���׷��̵� �̸�
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI costText;
    public Button upgradeButton;

    void Start()
    {
        UpdateUI();
        upgradeButton.onClick.AddListener(OnUpgradeClick);
    }

    void UpdateUI()
    {
        int level = UpgradeManager.Instance.GetUpgradeLevel(upgradeName);
        UpgradeData upgrade = UpgradeManager.Instance.upgradeList.Find(u => u.upgradeName == upgradeName);


        levelText.text = $"���� {level}";
        costText.text = upgrade.GetUpgradeCost(level).ToString();
        upgradeButton.interactable = UpgradeManager.Instance.playerGold >= upgrade.GetUpgradeCost(level);

    }

    void OnUpgradeClick()
    { 
            UpdateUI();
            UpgradeManager.Instance.UpdateGoldUI();
    }
}
