using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int stage = 1;
    public int gold = 1;
    public int criticalDamage = 10; // 기본 10%
    public float autoAttack = 0f; //자동 공격
    public int goldBonus = 0; // 골드 보너스 획득
    public int weaponAttack = 0; // 무기 공격력
    public int weaponCriticalChance = 0; // 무기 치명타 확률
    
    public int FinalAttackPower()
    {
        return weaponAttack;
    }
    
    public int FinalCriticalDamage()
    {
        return criticalDamage + weaponCriticalChance;
    }
    
    public int FinalGoldBonus()
    {
        return goldBonus;
    }
}
