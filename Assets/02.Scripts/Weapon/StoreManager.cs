using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreManager : MonoBehaviour
{
    public GoldManager goldManager; // GoldManager ����
    public Inventory playerInventory; // Inventory ����

    public int itemCost; // ������ ����

    // �������� Knife�� �����ϴ� �Լ�
    public void BuyKnife()
    {
        // ��ȭ �Ҹ� Ȯ��
        if (goldManager.SpendGold(itemCost))
        {
            // �������� �κ��丮�� �߰�
            Item knife = new Knife(); // Knife �������� ����
            playerInventory.AddItem(knife);

            // ���� �� UI ������Ʈ ���� �߰� ����
            Debug.Log("������ Į�� �κ��丮�� �߰��մϴ�!");
        }
    }
}
