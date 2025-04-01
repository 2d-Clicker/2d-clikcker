using System.Collections;
using System.Collections.Generic;
using UnityEditor.EditorTools;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    // 딕셔너리로 관리할 아이템 정보 (아이템 이름과 해당 아이템의 GameObject)
    public Dictionary<string, GameObject> knifeItems = new Dictionary<string, GameObject>();

    // UI 아이템을 인스펙터에서 할당
    public GameObject knifeGamja;  // 감자 칼
    public GameObject knifeShort;  // 짧은 칼
    public GameObject knifeBread;  // 빵 칼
    public GameObject knifeKitchen; // 식 칼
    public GameObject knifeChef;    // 중식도

    // 도구 관리 스크립트
    public ToolManager toolManager;

    void Start()
    {
        InitializeItems();
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

        foreach (var knife in knifeItems)
        {
            // 기본적으로 모든 아이템을 비활성화
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
        // 구매하면 PlayerPrefs에 상태 저장
        PlayerPrefs.SetInt(itemKey, 1);

        // 아이템 활성화
        if (knifeItems.ContainsKey(itemKey))
        {
            knifeItems[itemKey].SetActive(true);
            // 구매한 아이템을 도구 UI에 추가
            toolManager.AddItemToTool(itemKey);
        }

        // UI 업데이트
        Debug.Log(itemKey + " purchased!");
    }
}
