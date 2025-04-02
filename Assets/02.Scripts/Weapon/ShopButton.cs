using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopButton : MonoBehaviour
{
    public ShopManager shopManager;
    public string itemKey;  // ������ �������� Ű

    void Start()
    {
        // ��ư Ŭ�� �� �ش� ������ ���� �Լ� ȣ��
        GetComponent<Button>().onClick.AddListener(Purchase);
    }

    // ������ ���� �Լ�
    void Purchase()
    {
        if (shopManager != null)
        {
            // �������� �̹� ���ŵǾ����� Ȯ��
            if (IsItemAlreadyPurchased())
            {
                Debug.Log("�� �������� �̹� �����ϼ̽��ϴ�.");
                return;  // �̹� ������ �������̶�� ���Ÿ� �������� ����
            }
            else
            {
                // ������ ���� ����
                shopManager.PurchaseItem(itemKey);
                MarkItemAsPurchased(); // �������� ������ ������ ���
                GetComponent<Button>().interactable = false; // ���� �� ��ư ��Ȱ��ȭ
            }
        }
    }

    // �ش� �������� �̹� ���ŵǾ����� Ȯ��
    bool IsItemAlreadyPurchased()
    {
        // PlayerPrefs�� �ش� �������� �̹� ���ŵǾ����� Ȯ��
        return PlayerPrefs.GetInt(itemKey, 0) == 1; // 1�̸� ������ ������, 0�̸� �̱���
    }

    // �������� �����ߴٰ� ���
    void MarkItemAsPurchased()
    {
        PlayerPrefs.SetInt(itemKey, 1); // �ش� �������� �����ߴٰ� ���
        PlayerPrefs.Save(); // PlayerPrefs ����
    }
}
