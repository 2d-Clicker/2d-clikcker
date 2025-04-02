using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponEquipManager : MonoBehaviour
{
    public PlayerData playerData; // �÷��̾� ������ ����
    public WeaponStats equippedWeaponStats; // ������ ������ ����

    // ���⸦ �����ϴ� �Լ�
    public void EquipWeapon(WeaponStats weaponStats)
    {
        equippedWeaponStats = weaponStats; // ���� ������ ���� ����
    }


    // ���� ���� ���� �� �÷��̾� ���� �ʱ�ȭ
    public void UnequipWeapon()
    {
        // ������ ���� ȿ���� �ʱ�ȭ
        playerData.baseDamage -= playerData.equippedWeaponAttack;
        playerData.criticalChance -= playerData.equippedCritChance;
        playerData.criticalDamage -= playerData.equippedCritDamage;

        // �ʱ�ȭ�� ���� ������ 0���� ����
        playerData.equippedWeaponAttack = 0;
        playerData.equippedCritChance = 0;
        playerData.equippedCritDamage = 0;
    }
}


