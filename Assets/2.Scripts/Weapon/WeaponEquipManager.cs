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

    
}
