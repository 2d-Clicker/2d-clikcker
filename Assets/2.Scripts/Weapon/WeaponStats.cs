using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponStat", menuName = "Weapon/WeaponStats")]
public class WeaponStats : ScriptableObject
{
    public string weaponName; // 무기이름
    public int baseDamage; // 기본 데미지
    public float baseSpeed; // 기본 공격속도
    public float baseCritChance; // 기본 치명타 확률
    public float baseCritDamage; // 기본 치명타 배율

    [Header("강화 데이터")]
    public StatUpgrade[] statUpgrades; // 강화 단계에 따른 능력치 증가량

    public WeaponStats GetStatsForUpgradeLevel(int upgradeLevel)
    {
        if (upgradeLevel < 0 || upgradeLevel >= statUpgrades.Length)
        {
            Debug.LogWarning("Invalid upgrade level! Returning base stats.");
            return this; // 잘못된 레벨이면 기본값 반환
        }

        // 강화에 따른 능력치 증가량
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
    public int upgradeLevel; // 강화 레벨
    public int damageIncrease; // 데미지 증가
    public float speedIncrease; // 공격 속도 증가
    public float critChanceIncrease; // 치명타 확률 증가
    public float critDamageIncrease; // 치명타 배율 증가
}