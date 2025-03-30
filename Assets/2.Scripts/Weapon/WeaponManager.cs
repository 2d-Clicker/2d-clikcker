using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public WeaponStats WeaponStats; // 무기 강화 능력치
    public Inventory inventory; // 인벤토리 참조
    private Weapon equippedWeapon; // 장착된 무기

    // 장착된 무기 출력
    public void PrintEquippedWeapon()
    {
        if (equippedWeapon != null)
        {
            Debug.Log("Equipped Weapon: " + equippedWeapon.itemName);
        }
        else
        {
            Debug.Log("No weapon equipped.");
        }
    }

    // 무기 장착
    public void EquipWeapon(int upgradeLevel)
    {
        WeaponStats upgradedWeaponStats = WeaponStats.GetStatsForUpgradeLevel(upgradeLevel);

        Debug.Log("Equipped " + upgradedWeaponStats.weaponName);
        Debug.Log("Damage: " + upgradedWeaponStats.baseDamage);
        Debug.Log("Speed: " + upgradedWeaponStats.baseSpeed);
        Debug.Log("Crit Chance: " + upgradedWeaponStats.baseCritChance);
        Debug.Log("Crit Damage: " + upgradedWeaponStats.baseCritDamage);
    }
}
