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

    public WeaponStats GetStatsForUpgradeLevel(int upgradeLevel)
    {
        if (upgradeLevel < 0 || upgradeLevel >= statUpgrades.Length)
        {
            Debug.LogWarning("Invalid upgrade level! Returning base stats.");
            return this; // �߸��� �����̸� �⺻�� ��ȯ
        }

        // ��ȭ�� ���� �ɷ�ġ ������
        StatUpgrade upgrade = statUpgrades[upgradeLevel];

        WeaponStats upgradedStats = ScriptableObject.CreateInstance<WeaponStats>();
        upgradedStats.weaponName = weaponName;
        upgradedStats.baseDamage = baseDamage + upgrade.damageIncrease;
        upgradedStats.baseSpeed = baseSpeed + upgrade.speedIncrease;
        upgradedStats.baseCritChance = baseCritChance + upgrade.critChanceIncrease;
        upgradedStats.baseCritDamage = baseCritDamage + upgrade.critDamageIncrease;

        return upgradedStats;
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