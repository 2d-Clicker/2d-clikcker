using UnityEngine;

[CreateAssetMenu(fileName = "UpgradeData", menuName = "Upgrade System/Upgrade Data")]
public class UpgradeData : ScriptableObject
{
    public string upgradeName;      // ���׷��̵� �̸�
    public int maxLevel;            // �ִ� ����
    public float baseValue;         // �⺻ �ɷ�ġ ��
    public float increasePerLevel;  // ������ ������
    public int baseCost;            // �⺻ ���׷��̵� ���
    public float costMultiplier;    // ��� ���� ����

    // ���� ������ ���� ���׷��̵� ȿ�� ���
    public float GetUpgradeValue(int level)
    {
        return baseValue + (increasePerLevel * level);
    }

    // ���� ������ ���� ���׷��̵� ��� ���
    public int GetUpgradeCost(int level)
    {
        return Mathf.RoundToInt(baseCost * Mathf.Pow(costMultiplier, level));
    }
}
