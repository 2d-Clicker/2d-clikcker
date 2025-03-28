using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    public string upgradeName;  // 업그레이드 이름
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
        int playerGold = UpgradeManager.Instance.playerGold;

        levelText.text = $"레벨 {level}";
        costText.text = upgradeCost.ToString();

        if (playerGold >= upgradeCost)
        {
            costText.color = Color.black; 
        }
        else
        {
            costText.color = Color.red; 
        }
        // 버튼 활성화 여부
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
