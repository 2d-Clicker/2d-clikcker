using UnityEngine;
using System.Collections.Generic;

public class UpgradeManager : MonoBehaviour
{
    public static UpgradeManager Instance;
    public List<UpgradeData> upgradeList; // ScriptableObject 리스트
    public int playerGold = 100000; // 초기 골드
    private Dictionary<string, int> upgradeLevels = new Dictionary<string, int>();

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        LoadUpgradeData();
    }

    void LoadUpgradeData()
    {
        foreach (var upgrade in upgradeList)
        {
            if (!upgradeLevels.ContainsKey(upgrade.upgradeName))
                upgradeLevels[upgrade.upgradeName] = 1; // 초기 레벨 
        }
    }

    // 현재 업그레이드 레벨 가져오기
    public int GetUpgradeLevel(string upgradeName)
    {
        return upgradeLevels.ContainsKey(upgradeName) ? upgradeLevels[upgradeName] : 0;
    }

    // 업그레이드 시도
    public bool TryUpgrade(string upgradeName)
    {
        var upgrade = upgradeList.Find(u => u.upgradeName == upgradeName);
        if (upgrade == null) return false;

        int currentLevel = GetUpgradeLevel(upgradeName);
        if (currentLevel >= upgrade.maxLevel) return false; // 최대 레벨 도달

        int upgradeCost = upgrade.GetUpgradeCost(currentLevel);
        if (playerGold < upgradeCost) return false; // 골드 부족

        playerGold -= upgradeCost;
        upgradeLevels[upgradeName]++;
        UIManager.Instance.UpdateUI();
        return true;
    }
}
