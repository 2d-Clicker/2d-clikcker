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
            // 아이템이 이미 구매되었는지 확인
            if (IsItemAlreadyPurchased())
            {
                Debug.Log("이 아이템은 이미 구매하셨습니다.");
                return;  // 이미 구매한 아이템이라면 구매를 진행하지 않음
            }
            else
            {
                // 아이템 구매 진행
                shopManager.PurchaseItem(itemKey);
                MarkItemAsPurchased(); // 아이템을 구매한 것으로 기록
                GetComponent<Button>().interactable = false; // 구매 후 버튼 비활성화
            }
        }
    }

    // 해당 아이템이 이미 구매되었는지 확인
    bool IsItemAlreadyPurchased()
    {
        // PlayerPrefs로 해당 아이템이 이미 구매되었는지 확인
        return PlayerPrefs.GetInt(itemKey, 0) == 1; // 1이면 구매한 아이템, 0이면 미구매
    }

    // 아이템을 구매했다고 기록
    void MarkItemAsPurchased()
    {
        PlayerPrefs.SetInt(itemKey, 1); // 해당 아이템을 구매했다고 기록
        PlayerPrefs.Save(); // PlayerPrefs 저장
    }
}
