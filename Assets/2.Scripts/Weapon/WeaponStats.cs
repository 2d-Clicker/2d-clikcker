using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponStat", menuName = "Weapon/WeaponStats")]
public class WeaponStats : ScriptableObject
{
    public string weaponName; // �����̸�
    public int baseDamage; // �⺻ ������
    public float baseSpeed; // �⺻ ���ݼӵ�
    public float baseCritChance; // �⺻ ġ��Ÿ Ȯ��
    public float baseCritDamage; // �⺻ ġ��Ÿ ����

    [Header("��ȭ ������")]
    public StatUpgrade[] statUpgrades; // ��ȭ �ܰ迡 ���� �ɷ�ġ ������

    public Sprite itemIcon; // ���� ������ �̹���
    public string itemDescription; // ���� ����

    // ��ȭ ������ ���� �ɷ�ġ ���
    public WeaponStats GetStatsForUpgradeLevel(int upgradeLevel, WeaponStats currentStats)
    {
        if (upgradeLevel < 0 || upgradeLevel >= statUpgrades.Length)
        {
            return currentStats; // �߸��� �����̸� ���� �ɷ�ġ �״�� ��ȯ
        }

        // ��ȭ�� ���� �ɷ�ġ ������
        StatUpgrade upgrade = statUpgrades[upgradeLevel];

        // ���� �ɷ�ġ�� ��ȭ���� �߰�
        currentStats.baseDamage += upgrade.damageIncrease;
        currentStats.baseSpeed += upgrade.speedIncrease;
        currentStats.baseCritChance += upgrade.critChanceIncrease;
        currentStats.baseCritDamage += upgrade.critDamageIncrease;

        return currentStats;
    }
}

[System.Serializable]
public class StatUpgrade
{
    public int upgradeLevel; // ��ȭ ����
    public int damageIncrease; // ������ ����
    public float speedIncrease; // ���� �ӵ� ����
    public float critChanceIncrease; // ġ��Ÿ Ȯ�� ����
    public float critDamageIncrease; // ġ��Ÿ ���� ����
}