using System.Collections;
using System.Collections.Generic;
using UnityEditor.EditorTools;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    // 딕셔너리로 관리할 아이템 정보 (아이템 이름 & 해당 아이템의 GameObject)
    public Dictionary<string, GameObject> knifeItems = new Dictionary<string, GameObject>();
    // 아이템 가격 설정
    public Dictionary<string, int> itemPrices = new Dictionary<string, int>();

    // UI 아이템을 인스펙터에서 할당
    public GameObject knifeGamja; 
    public GameObject knifeShort;
    public GameObject knifeBread;
    public GameObject knifeKitchen;
    public GameObject knifeChef;

    public GoldManager goldManager;
    public ToolManager toolManager;

    void Start()
    {
        ResetPlayerPrefs(); // PlayerPrefs 초기화 
        InitializeItems();
    }
    
    private void ResetPlayerPrefs()
    {
        PlayerPrefs.DeleteAll(); // 아이템 구입기록 삭제
        PlayerPrefs.Save(); // 변경 사항 저장
    }

    // 아이템 초기화 및 딕셔너리로 관리하는 함수
    private void InitializeItems()
    {
        // 모든 아이템을 비활성화 (게임 시작 시 초기화)
        knifeItems.Add("KnifeGamja", knifeGamja);
        knifeItems.Add("KnifeShort", knifeShort);
        knifeItems.Add("KnifeBread", knifeBread);
        knifeItems.Add("KnifeKitchen", knifeKitchen);
        knifeItems.Add("KnifeChef", knifeChef);

        // 각 아이템 가격 설정
        itemPrices.Add("KnifeGamja", 10);
        itemPrices.Add("KnifeShort", 500);
        itemPrices.Add("KnifeBread", 1000);
        itemPrices.Add("KnifeKitchen", 5000);
        itemPrices.Add("KnifeChef", 30000);

        foreach (var knife in knifeItems)
        {
            // 모든 아이템을 비활성화
            knife.Value.SetActive(false);
        }

        // 구매한 아이템만 활성화
        foreach (var knife in knifeItems)
        {
            if (IsItemPurchased(knife.Key))
            {
                knife.Value.SetActive(true);
            }
        }
    }

    // 아이템이 구매되었는지 체크하는 함수
    private bool IsItemPurchased(string itemKey)
    {
        // PlayerPrefs에 저장된 구매 여부로 체크
        return PlayerPrefs.GetInt(itemKey, 0) > 0;
    }

    // 아이템 구매 함수 (구매 시 PlayerPrefs에 저장)
    public void PurchaseItem(string itemKey)
    {
        // 아이템 가격 확인
        int itemPrice = itemPrices[itemKey];

        // 재화가 충분한지 확인
        if (goldManager.SpendGold(itemPrice))
        {
            PlayerPrefs.SetInt(itemKey, 1);  // 아이템 구매 상태 저장
            if (knifeItems.ContainsKey(itemKey)) // 아이템 활성화
            {
                knifeItems[itemKey].SetActive(true);
                toolManager.AddItemToTool(itemKey); // 구매한 아이템을 도구 UI에 추가
            }
            Debug.Log(itemKey + " 구매완료!");
        }
        else
        {
            Debug.Log("너무 비싸요ㅠ.ㅠ " + itemKey);
        }
    }
}
