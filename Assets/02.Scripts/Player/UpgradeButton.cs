using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    public string upgradeName;  // 업그레이드 이름
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI costText;
    public Button upgradeButton;
    public GoldManager goldManager;

    private int lastGold = -1; 

    void Start()
    {
        goldManager = FindObjectOfType<GoldManager>();
        if (goldManager == null)
        {
            Debug.LogError("GoldManager를 찾을 수 없습니다.");
            return;
        }

        UpdateUI();
        upgradeButton.onClick.AddListener(OnUpgradeClick);
    }

    void Update()
    {
        int currentGold = goldManager.GetCurrentGold();

        if (currentGold != lastGold)
        {
            lastGold = currentGold;
            UpdateUI();
        }
    }

    void UpdateUI()
    {
        int level = UpgradeManager.Instance.GetUpgradeLevel(upgradeName);
        UpgradeData upgrade = UpgradeManager.Instance.upgradeList.Find(u => u.upgradeName == upgradeName);

        if (upgrade == null)
        {
            Debug.LogError($"업그레이드 데이터를 찾을 수 없습니다: {upgradeName}");
            return;
        }

        int upgradeCost = upgrade.GetUpgradeCost(level);
        int playerGold = goldManager.GetCurrentGold();

        levelText.text = $"{level}";

        bool isMaxLevel = level >= upgrade.maxLevel;

        if (isMaxLevel)
        {
            costText.text = "";  
            costText.color = Color.gray;  
            upgradeButton.interactable = false; 
        }
        else
        {
            costText.text = upgradeCost.ToString();
            costText.color = (playerGold >= upgradeCost) ? Color.black : Color.red;
            upgradeButton.interactable = playerGold >= upgradeCost;
        }
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
            Debug.LogWarning("업그레이드 실패");
        }
    }
}
