using UnityEngine;
using System.Collections.Generic;

public class UpgradeManager : MonoBehaviour
{
    public static UpgradeManager Instance;
    public List<UpgradeData> upgradeList; // ScriptableObject ����Ʈ
    public int playerGold = 100000; // �ʱ� ���
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
                upgradeLevels[upgrade.upgradeName] = 1; // �ʱ� ���� 
        }
    }

    // ���� ���׷��̵� ���� ��������
    public int GetUpgradeLevel(string upgradeName)
    {
        return upgradeLevels.ContainsKey(upgradeName) ? upgradeLevels[upgradeName] : 0;
    }

    // ���׷��̵� �õ�
    public bool TryUpgrade(string upgradeName)
    {
        var upgrade = upgradeList.Find(u => u.upgradeName == upgradeName);
        if (upgrade == null) return false;

        int currentLevel = GetUpgradeLevel(upgradeName);
        if (currentLevel >= upgrade.maxLevel) return false; // �ִ� ���� ����

        int upgradeCost = upgrade.GetUpgradeCost(currentLevel);
        if (playerGold < upgradeCost) return false; // ��� ����

        playerGold -= upgradeCost;
        upgradeLevels[upgradeName]++;
        UIManager.Instance.UpdateUI();
        return true;
    }
}
