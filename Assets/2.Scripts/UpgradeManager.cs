using System.Collections.Generic;
using UnityEngine;
using TMPro; // ��� UI ǥ�ø� ���� �߰�

public class UpgradeManager : MonoBehaviour
{
    public static UpgradeManager Instance;

    public List<UpgradeData> upgradeList;  // ���׷��̵� ������ ����Ʈ
    public int playerGold = 100;  // ���� ���� ��� (�׽�Ʈ�� �⺻��)

    public TextMeshProUGUI goldText;  // ���� ��带 ǥ���� UI (Inspector���� ����)

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
        UpdateGoldUI(); // ���� ���� �� UI �ʱ�ȭ
    }

    public void UpdateGoldUI()
    {
        if (goldText != null)
        {
            goldText.text = $"���: {playerGold}";
        }
    }

    public int GetUpgradeLevel(string upgradeName)
    {
        return upgradeLevels.ContainsKey(upgradeName) ? upgradeLevels[upgradeName] : 1;
    }

    public bool TryUpgrade(string upgradeName)
    {
        UpgradeData upgrade = upgradeList.Find(u => u.upgradeName == upgradeName);
      

        int currentLevel = GetUpgradeLevel(upgradeName);
        if (currentLevel >= upgrade.maxLevel)
        {
            Debug.Log("�ִ� ������ �����߽��ϴ�.");
            return false;
        }

        int upgradeCost = upgrade.GetUpgradeCost(currentLevel);
        if (playerGold < upgradeCost)
        {
            Debug.Log("��尡 �����մϴ�.");
            return false;
        }

        // ��� ����
        playerGold -= upgradeCost;
        upgradeLevels[upgradeName]++;

        // �÷��̾� �ɷ�ġ ���� 
        float newStatValue = upgrade.GetUpgradeValue(upgradeLevels[upgradeName]);
        PlayerStats.Instance.ApplyUpgrade(upgradeName, newStatValue);
        //  UI ����
        UpdateGoldUI();

        return true;
    }

}
