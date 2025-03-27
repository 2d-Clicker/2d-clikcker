using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    public string upgradeName;
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


        int upgradeCost = upgrade.GetUpgradeCost(level);

       

        levelText.text = $"·¹º§ {level}";
        costText.text = upgradeCost.ToString();
        upgradeButton.interactable = UpgradeManager.Instance.playerGold >= upgradeCost;
    }

    void OnUpgradeClick()
    {
        if (UpgradeManager.Instance.TryUpgrade(upgradeName))
        {
            UpdateUI();
        }
    }
}
