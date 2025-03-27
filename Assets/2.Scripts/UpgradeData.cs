using UnityEngine;

[CreateAssetMenu(fileName = "Upgrade Data", menuName = "Upgrade System/Upgrade Data")]
public class UpgradeData : ScriptableObject
{
    public string upgradeName;      // ���׷��̵� �̸� (ġ��Ÿ, �ڵ� ����, ��� ȹ��)
    public int maxLevel;            // �ִ� ����
    public float baseValue;         // �⺻ �� (��: ġ��Ÿ 10%)
    public float increasePerLevel;  // ������ ������ (��: +2%)
    public int baseCost;            // �⺻ ���׷��̵� ���
    public float costMultiplier;    // ��� ���� ����

 
}
