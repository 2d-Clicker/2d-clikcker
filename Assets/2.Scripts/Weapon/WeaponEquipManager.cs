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

    
}
