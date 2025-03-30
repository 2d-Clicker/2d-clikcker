using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType
{

    PotatoKnife, // 1 감자 칼
    SmallKnife, // 2 작은 칼
    BreadKnife, // 3 빵칼
    SharpKnife, // 4 날카로운 칼
    ChefKnife // 5 쉐프의 칼

}

[System.Serializable]
public class Weapon : Item
{
    public WeaponType weapontype; // 무기 종류
    public int weaponDamage; // 무기 데미지
    public float weaponSpeed; // 공격 속도(초당 공격 횟수)
    public float critChance; // 치명타 확률
    public float critDamageMultiplier; // 치명타 배율
    public float accuracy; // 명중률


    // 칼의 특성(예: 치명타, 공격 속도 등)을 게임에서 사용하는 메소드
    public int CalculateDamage()
    {
        // 치명타 확률이 적용되는 부분 (0 ~ 1 사이의 값으로, 확률을 나타냄)
        if (Random.value <= critChance)
        {
            // 치명타가 발생했을 때 데미지 계산 (기본 데미지 * 치명타 배율)
            return Mathf.RoundToInt(weaponDamage * critDamageMultiplier);
        }
        return weaponDamage;
    }



}
