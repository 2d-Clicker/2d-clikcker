using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopButton : MonoBehaviour
{
    public ShopManager shopManager;
    public string itemKey;  // 구매할 아이템의 키

    void Start()
    {
        // 버튼 클릭 시 해당 아이템 구매 함수 호출
        GetComponent<Button>().onClick.AddListener(Purchase);
    }

    // 아이템 구매 함수
    void Purchase()
    {
        if (shopManager != null)
        {
            shopManager.PurchaseItem(itemKey);
        }
    }
}
