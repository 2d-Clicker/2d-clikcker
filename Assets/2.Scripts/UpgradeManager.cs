using System.Collections.Generic;
using UnityEngine;
using TMPro; // 골드 UI 표시를 위한 추가

public class UpgradeManager : MonoBehaviour
{
    public static UpgradeManager Instance;

    public List<UpgradeData> upgradeList;  // 업그레이드 데이터 리스트
    public int playerGold = 100;  // 현재 보유 골드 (테스트용 기본값)

    public TextMeshProUGUI goldText;  // 현재 골드를 표시할 UI (Inspector에서 연결)

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
        UpdateGoldUI(); // 게임 시작 시 UI 초기화
    }

    public void UpdateGoldUI()
    {
        if (goldText != null)
        {
            goldText.text = $"{playerGold}";
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
        if (playerGold < upgradeCost)
        {
            Debug.Log("골드 부족");
            return false;
        }

        playerGold -= upgradeCost;
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
