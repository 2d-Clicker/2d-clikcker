using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public static UpgradeManager Instance;

    public List<UpgradeData> upgradeList;  // 업그레이드 데이터 리스트
    private GoldManager goldManager;

    private Dictionary<string, int> upgradeLevels = new Dictionary<string, int>();

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (var upgrade in upgradeList)
        {
            upgradeLevels[upgrade.upgradeName] = 0;
        }
    }

    void Start()
    {
        goldManager = FindObjectOfType<GoldManager>();  // GoldManager 찾기
        if (goldManager == null)
        {
            Debug.LogError("GoldManager를 찾을 수 없습니다! 골드 UI 업데이트 불가");
        }

        UpdateGoldUI();
    }

    public void UpdateGoldUI()
    {
        if (goldManager != null)
        {
            goldManager.UpdateGoldUI();
        }
    }

    public int GetUpgradeLevel(string upgradeName)
    {
        return upgradeLevels.ContainsKey(upgradeName) ? upgradeLevels[upgradeName] : 0;
    }

    public bool TryUpgrade(string upgradeName)
    {
        UpgradeData upgrade = upgradeList.Find(u => u.upgradeName == upgradeName);
        int currentLevel = GetUpgradeLevel(upgradeName);

        if (currentLevel >= upgrade.maxLevel)
        {
            Debug.Log("최대 레벨");
            return false;
        }

        int upgradeCost = upgrade.GetUpgradeCost(currentLevel);
        if (goldManager == null || !goldManager.SpendGold(upgradeCost))
        {
            Debug.Log("골드 부족");
            if (goldManager != null)
            {
                goldManager.ShowPopup();
            }
            return false;
        }

        upgradeLevels[upgradeName]++;
        float newStatValue = upgrade.GetUpgradeValue(upgradeLevels[upgradeName]);

        if (PlayerStats.Instance != null)
        {
            PlayerStats.Instance.ApplyUpgrade(upgradeName, newStatValue);
        }

        UpdateGoldUI();
        return true;
    }

}

