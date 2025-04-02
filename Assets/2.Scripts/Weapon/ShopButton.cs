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
            shopManager.PurchaseItem(itemKey);
        }
    }
}
