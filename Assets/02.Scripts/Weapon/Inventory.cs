using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> items = new List<Item>(); // �κ��丮 ������ ����Ʈ

    private Weapon equippedWeapon; // ������ ����

    // ������ �߰�
    public void AddItem(Item item)
    {
        items.Add(item);
    }

    // ���� ����
    public void EquipWeapon(Weapon weapon)
    {
        if (weapon is Weapon)
        {
            equippedWeapon = weapon;
        }
        else
        {
            Debug.Log("���õ� �������� ���Ⱑ �ƴմϴ�.");
        }
    }
}
