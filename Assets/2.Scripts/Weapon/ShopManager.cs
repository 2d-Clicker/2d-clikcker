using System.Collections;
using System.Collections.Generic;
using UnityEditor.EditorTools;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    // ��ųʸ��� ������ ������ ���� (������ �̸��� �ش� �������� GameObject)
    public Dictionary<string, GameObject> knifeItems = new Dictionary<string, GameObject>();

    // UI �������� �ν����Ϳ��� �Ҵ�
    public GameObject knifeGamja;  // ���� Į
    public GameObject knifeShort;  // ª�� Į
    public GameObject knifeBread;  // �� Į
    public GameObject knifeKitchen; // �� Į
    public GameObject knifeChef;    // �߽ĵ�

    // ���� ���� ��ũ��Ʈ
    public ToolManager toolManager;

    void Start()
    {
        InitializeItems();
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

        foreach (var knife in knifeItems)
        {
            // �⺻������ ��� �������� ��Ȱ��ȭ
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
        // �����ϸ� PlayerPrefs�� ���� ����
        PlayerPrefs.SetInt(itemKey, 1);

        // ������ Ȱ��ȭ
        if (knifeItems.ContainsKey(itemKey))
        {
            knifeItems[itemKey].SetActive(true);
            // ������ �������� ���� UI�� �߰�
            toolManager.AddItemToTool(itemKey);
        }

        // UI ������Ʈ
        Debug.Log(itemKey + " purchased!");
    }
}
