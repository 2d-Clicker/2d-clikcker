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

    public GoldManager goldManager;

    void Start()
    {
        goldManager = FindObjectOfType<GoldManager>();
        if(goldManager == null)
        {
            Debug.LogError("GoldManager를 찾을수없습니다.");
            return;
        }
        UpdateUI();
        upgradeButton.onClick.AddListener(OnUpgradeClick);
    }
    private void Update()
    {
        
      UpdateUI();
        
    }

    void UpdateUI()
    {
        int level = UpgradeManager.Instance.GetUpgradeLevel(upgradeName);
        UpgradeData upgrade = UpgradeManager.Instance.upgradeList.Find(u => u.upgradeName == upgradeName);

        int upgradeCost = upgrade.GetUpgradeCost(level);
        int playerGold = goldManager != null ? goldManager.GetCurrentGold() : 0;

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