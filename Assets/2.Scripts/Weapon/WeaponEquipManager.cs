using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponEquipManager : MonoBehaviour
{
    public PlayerData playerData; // 플레이어 데이터 참조
    public WeaponStats equippedWeaponStats; // 장착된 무기의 스텟

    // 무기를 장착하는 함수
    public void EquipWeapon(WeaponStats weaponStats)
    {
        equippedWeaponStats = weaponStats; // 새로 장착된 무기 스텟
    }


    // 무기 장착 해제 시 플레이어 스탯 초기화
    public void UnequipWeapon()
    {
        // 장착된 무기 효과를 초기화
        playerData.baseDamage -= playerData.equippedWeaponAttack;
        playerData.criticalChance -= playerData.equippedCritChance;
        playerData.criticalDamage -= playerData.equippedCritDamage;

        // 초기화된 무기 스탯을 0으로 설정
        playerData.equippedWeaponAttack = 0;
        playerData.equippedCritChance = 0;
        playerData.equippedCritDamage = 0;
    }
}


