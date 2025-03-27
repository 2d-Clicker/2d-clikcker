using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Text Coin;
    public GameObject PopupError;

    private void Awake()
    {
        Instance = this;
    }
}
