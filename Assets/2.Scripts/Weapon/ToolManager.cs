using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolManager : MonoBehaviour
{
    // ���� ����
    public GameObject knifeSlot1;  // Į ���� 1
    public GameObject knifeSlot2;  // Į ���� 2
    public GameObject knifeSlot3;  // Į ���� 3
    public GameObject knifeSlot4;  // Į ���� 4
    public GameObject knifeSlot5;  // Į ���� 5

    // ������ �������� �߰��ϴ� �Լ�
    public void AddItemToTool(string itemKey)
    {
        switch (itemKey)
        {
            case "KnifeGamja":
                knifeSlot1.SetActive(true);
                break;
            case "KnifeShort":
                knifeSlot2.SetActive(true);
                break;
            case "KnifeBread":
                knifeSlot3.SetActive(true);
                break;
            case "KnifeKitchen":
                knifeSlot4.SetActive(true);
                break;
            case "KnifeChef":
                knifeSlot5.SetActive(true);
                break;
            default:
                Debug.LogError("Unknown item key: " + itemKey);
                break;
        }
    }
}
