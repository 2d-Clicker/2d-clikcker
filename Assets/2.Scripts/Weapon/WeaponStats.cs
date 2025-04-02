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

    public Sprite itemIcon; // 무기 아이콘 이미지
    public string itemDescription; // 무기 설명

    [HideInInspector] public int upgradeLevel = 0; // 현재 강화 레벨

    // 강화 레벨에 따른 능력치 계산
    public WeaponStats GetStatsForUpgradeLevel(int upgradeLevel, WeaponStats currentStats)
    {
        if (upgradeLevel < 0 || upgradeLevel >= statUpgrades.Length)
        {
            return currentStats; // 잘못된 레벨이면 기존 능력치 그대로 반환
        }

        // 강화에 따른 능력치 증가량
        StatUpgrade upgrade = statUpgrades[upgradeLevel];

        // 기존 능력치에 강화값을 추가
        currentStats.baseDamage += upgrade.damageIncrease;
        currentStats.baseSpeed += upgrade.speedIncrease;
        currentStats.baseCritChance += upgrade.critChanceIncrease;
        currentStats.baseCritDamage += upgrade.critDamageIncrease;

        return currentStats;
    }

    // 무기 능력치를 기본값으로 복원하는 메서드
    public void ResetToDefault()
    {
        baseDamage = statUpgrades[0].damageIncrease;
        baseSpeed = statUpgrades[0].speedIncrease;
        baseCritChance = statUpgrades[0].critChanceIncrease;
        baseCritDamage = statUpgrades[0].critDamageIncrease;

        upgradeLevel = 0; // 강화 레벨 초기화
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