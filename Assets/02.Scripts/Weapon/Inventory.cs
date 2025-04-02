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
    }

    // 무기 장착
    public void EquipWeapon(Weapon weapon)
    {
        if (weapon is Weapon)
        {
            equippedWeapon = weapon;
        }
        else
        {
            Debug.Log("선택된 아이템은 무기가 아닙니다.");
        }
    }
}
