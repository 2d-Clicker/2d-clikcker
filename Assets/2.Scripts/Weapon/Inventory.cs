using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> items = new List<Item>(); // 인벤토리 아이템 리스트

    private Weapon equippedWeapon; // 장착된 무기

    // 아이템 추가
    public void AddItem(Item item)
    {
        items.Add(item);
        Debug.Log(item.itemName + " added to inventory.");
    }

    //// 아이템 제거
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

    // 무기 장착
    public void EquipWeapon(Weapon weapon)
    {
        if (weapon is Weapon)
        {
            equippedWeapon = weapon;
            Debug.Log("Equipped" + weapon.itemName);
        }
        else
        {
            Debug.Log("선택된 아이템은 무기가 아닙니다.");
        }
    }

    // 현재 장착된 무기 출력
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

    // 인벤토리 내용 출력 (디버깅용)
    public void PrintInventory()
    {
        foreach (Item item in items)
        {
            Debug.Log("Item: " + item.itemName);
        }
    }
}
