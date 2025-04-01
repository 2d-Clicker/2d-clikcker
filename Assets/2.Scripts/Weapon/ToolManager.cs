using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolManager : MonoBehaviour
{
    // µµ±¸ ½½·Ô
    public GameObject knifeSlot1;  // Ä® ½½·Ô 1
    public GameObject knifeSlot2;  // Ä® ½½·Ô 2
    public GameObject knifeSlot3;  // Ä® ½½·Ô 3
    public GameObject knifeSlot4;  // Ä® ½½·Ô 4
    public GameObject knifeSlot5;  // Ä® ½½·Ô 5

    // µµ±¸¿¡ ¾ÆÀÌÅÛÀ» Ãß°¡ÇÏ´Â ÇÔ¼ö
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
