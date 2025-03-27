using UnityEngine;

[System.Serializable]
public class PlayerData
{
    //플레이어 데이터 (치명타, 치명타 확률, 골드 획득)
    public int stage; // 현재 진행중인 스테이지
    public int coin; // 보유 돈
    public int critical; // 치명타
    public float criticalPro; // 치명타 확률
    public float goldBonus; // 골드 획득 보너스


    //최종 무기 스탯 계산 ()
    //public int FinalWeaponStat(int weaponstat)
    //{
    //    return weaponstat;
    //}

    //최종 공격력 계산 (기본 플레이어 공격력 + 업그레이드 플레이어 공격력 + 업그레이드 칼 공격력)
    public int FinalAttack(int upgradeplayerstat, int weaponstat)
    {
        return critical + weaponstat + upgradeplayerstat;
    }

    //최종 치명타 확률 계산 (기본 치명타 확률 + 업그레이드 플레이어 치명타 확률 + 업그레이드 칼 치명타 확률)
    public float FinalCritical(float upgradeplayerstat, float upgradeweaponstat)
    {
        return criticalPro + upgradeweaponstat;
    }

    //최종 골드 획득 보너스 계산 (기본 골드 획득 보너스 + 업그레이드 된 칼 골드 획득 보너스)

}
