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
        Debug.Log(item.itemName + " added to inventory.");
    }

    //// ������ ����
    //public void RemoveItem(Item item)
    //{
    //    if (items.Contains(item))
    //    {
    //        items.Remove(item);
    //        Debug.Log(item.itemName + " removed from inventory.");
    //    }
    //    else
    //    {
    //        Debug.Log("Item not found in inventory.");
    //    }
    //}

    // ���� ����
    public void EquipWeapon(Weapon weapon)
    {
        if (weapon is Weapon)
        {
            equippedWeapon = weapon;
            Debug.Log("Equipped" + weapon.itemName);
        }
        else
        {
            Debug.Log("���õ� �������� ���Ⱑ �ƴմϴ�.");
        }
    }

    // ���� ������ ���� ���
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

    // �κ��丮 ���� ��� (������)
    public void PrintInventory()
    {
        foreach (Item item in items)
        {
            Debug.Log("Item: " + item.itemName);
        }
    }
}
