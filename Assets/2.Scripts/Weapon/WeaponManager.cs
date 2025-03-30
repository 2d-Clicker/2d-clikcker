using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public WeaponStats WeaponStats; // ���� ��ȭ �ɷ�ġ
    public Inventory inventory; // �κ��丮 ����
    private Weapon equippedWeapon; // ������ ����

    // ������ ���� ���
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

    // ���� ����
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
