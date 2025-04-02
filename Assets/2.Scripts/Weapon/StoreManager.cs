using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreManager : MonoBehaviour
{
    public GoldManager goldManager; // GoldManager 연결
    public Inventory playerInventory; // Inventory 연결

    public int itemCost; // 아이템 가격

    // 상점에서 Knife를 구매하는 함수
    public void BuyKnife()
    {
        // 재화 소모 확인
        if (goldManager.SpendGold(itemCost))
        {
            // 아이템을 인벤토리에 추가
            Item knife = new Knife(); // Knife 아이템을 생성
            playerInventory.AddItem(knife);

            // 구매 후 UI 업데이트 등의 추가 로직
            Debug.Log("구매한 칼을 인벤토리에 추가합니다!");
        }
    }
}
