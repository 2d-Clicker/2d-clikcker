using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType
{

    PotatoKnife, // 1 ���� Į
    SmallKnife, // 2 ���� Į
    BreadKnife, // 3 ��Į
    SharpKnife, // 4 ��ī�ο� Į
    ChefKnife // 5 ������ Į

}

[System.Serializable]
public class Weapon : Item
{
    public WeaponType weapontype; // ���� ����
    public int weaponDamage; // ���� ������
    public float weaponSpeed; // ���� �ӵ�(�ʴ� ���� Ƚ��)
    public float critChance; // ġ��Ÿ Ȯ��
    public float critDamageMultiplier; // ġ��Ÿ ����
    public float accuracy; // ���߷�


    // Į�� Ư��(��: ġ��Ÿ, ���� �ӵ� ��)�� ���ӿ��� ����ϴ� �޼ҵ�
    public int CalculateDamage()
    {
        // ġ��Ÿ Ȯ���� ����Ǵ� �κ� (0 ~ 1 ������ ������, Ȯ���� ��Ÿ��)
        if (Random.value <= critChance)
        {
            // ġ��Ÿ�� �߻����� �� ������ ��� (�⺻ ������ * ġ��Ÿ ����)
            return Mathf.RoundToInt(weaponDamage * critDamageMultiplier);
        }
        return weaponDamage;
    }



}
