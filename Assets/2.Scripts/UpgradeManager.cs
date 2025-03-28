using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public static UpgradeManager Instance;
    public List<UpgradeData> upgradeList;  // ���׷��̵� ������ ����Ʈ
    public int playerGold = 100;  // ���� ���

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
            Debug.LogError($"���׷��̵� [{upgradeName}]�� ã�� �� �����ϴ�.");
            return false;
        }

        int currentLevel = GetUpgradeLevel(upgradeName);
        if (currentLevel >= upgrade.maxLevel)
        {
            Debug.Log("�ִ� ���� ����");
            return false;
        }

        int cost = upgrade.GetUpgradeCost(currentLevel);
        if (playerGold < cost)
        {
            Debug.Log("��� ����");
            return false;
        }

        // ��� ���� �� ���׷��̵� ����
        playerGold -= cost;
        PlayerPrefs.SetInt(upgradeName, currentLevel + 1);

        // �ɷ�ġ �ݿ�
        float addedValue = upgrade.increasePerLevel;
        PlayerStats.Instance.ApplyUpgrade(upgradeName, addedValue);

        return true;
    }

    public int GetUpgradeLevel(string upgradeName)
    {
        return PlayerPrefs.GetInt(upgradeName, 0);
    }
}
