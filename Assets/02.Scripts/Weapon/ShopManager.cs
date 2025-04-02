using System.Collections;
using System.Collections.Generic;
using UnityEditor.EditorTools;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    // ��ųʸ��� ������ ������ ���� (������ �̸� & �ش� �������� GameObject)
    public Dictionary<string, GameObject> knifeItems = new Dictionary<string, GameObject>();
    // ������ ���� ����
    public Dictionary<string, int> itemPrices = new Dictionary<string, int>();

    // UI �������� �ν����Ϳ��� �Ҵ�
    public GameObject knifeGamja; 
    public GameObject knifeShort;
    public GameObject knifeBread;
    public GameObject knifeKitchen;
    public GameObject knifeChef;

    public GoldManager goldManager;
    public ToolManager toolManager;

    void Start()
    {
        ResetPlayerPrefs(); // PlayerPrefs �ʱ�ȭ 
        InitializeItems();
    }
    
    private void ResetPlayerPrefs()
    {
        PlayerPrefs.DeleteAll(); // ������ ���Ա�� ����
        PlayerPrefs.Save(); // ���� ���� ����
    }

    // ������ �ʱ�ȭ �� ��ųʸ��� �����ϴ� �Լ�
    private void InitializeItems()
    {
        // ��� �������� ��Ȱ��ȭ (���� ���� �� �ʱ�ȭ)
        knifeItems.Add("KnifeGamja", knifeGamja);
        knifeItems.Add("KnifeShort", knifeShort);
        knifeItems.Add("KnifeBread", knifeBread);
        knifeItems.Add("KnifeKitchen", knifeKitchen);
        knifeItems.Add("KnifeChef", knifeChef);

        // �� ������ ���� ����
        itemPrices.Add("KnifeGamja", 10);
        itemPrices.Add("KnifeShort", 500);
        itemPrices.Add("KnifeBread", 1000);
        itemPrices.Add("KnifeKitchen", 5000);
        itemPrices.Add("KnifeChef", 30000);

        foreach (var knife in knifeItems)
        {
            // ��� �������� ��Ȱ��ȭ
            knife.Value.SetActive(false);
        }

        // ������ �����۸� Ȱ��ȭ
        foreach (var knife in knifeItems)
        {
            if (IsItemPurchased(knife.Key))
            {
                knife.Value.SetActive(true);
            }
        }
    }

    // �������� ���ŵǾ����� üũ�ϴ� �Լ�
    private bool IsItemPurchased(string itemKey)
    {
        // PlayerPrefs�� ����� ���� ���η� üũ
        return PlayerPrefs.GetInt(itemKey, 0) > 0;
    }

    // ������ ���� �Լ� (���� �� PlayerPrefs�� ����)
    public void PurchaseItem(string itemKey)
    {
        // ������ ���� Ȯ��
        int itemPrice = itemPrices[itemKey];

        // ��ȭ�� ������� Ȯ��
        if (goldManager.SpendGold(itemPrice))
        {
            PlayerPrefs.SetInt(itemKey, 1);  // ������ ���� ���� ����
            if (knifeItems.ContainsKey(itemKey)) // ������ Ȱ��ȭ
            {
                knifeItems[itemKey].SetActive(true);
                toolManager.AddItemToTool(itemKey); // ������ �������� ���� UI�� �߰�
            }
            Debug.Log(itemKey + " ���ſϷ�!");
        }
        else
        {
            Debug.Log("�ʹ� ��ο��.�� " + itemKey);
        }
    }
}
