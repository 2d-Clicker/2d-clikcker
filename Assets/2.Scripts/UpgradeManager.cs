using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public static UpgradeManager Instance;
    public List<UpgradeData> upgradeList;  // 업그레이드 데이터 리스트
    public int playerGold = 100;  // 시작 골드

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
    }

    public bool TryUpgrade(string upgradeName)
    {
        UpgradeData upgrade = upgradeList.Find(u => u.upgradeName == upgradeName);
        if (upgrade == null)
        {
            Debug.LogError($"업그레이드 [{upgradeName}]를 찾을 수 없습니다.");
            return false;
        }

        int currentLevel = GetUpgradeLevel(upgradeName);
        if (currentLevel >= upgrade.maxLevel)
        {
            Debug.Log("최대 레벨 도달");
            return false;
        }

        int cost = upgrade.GetUpgradeCost(currentLevel);
        if (playerGold < cost)
        {
            Debug.Log("골드 부족");
            return false;
        }

        // 골드 차감 및 업그레이드 적용
        playerGold -= cost;
        PlayerPrefs.SetInt(upgradeName, currentLevel + 1);

        // 능력치 반영
        float addedValue = upgrade.increasePerLevel;
        PlayerStats.Instance.ApplyUpgrade(upgradeName, addedValue);

        return true;
    }

    public int GetUpgradeLevel(string upgradeName)
    {
        return PlayerPrefs.GetInt(upgradeName, 0);
    }
}
