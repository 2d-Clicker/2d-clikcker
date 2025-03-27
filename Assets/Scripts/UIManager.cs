using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public TextMeshProUGUI goldText;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        UpdateUI();  // 시작할 때 UI 갱신
    }

    public void UpdateUI()
    {
        goldText.text = "골드: " + UpgradeManager.Instance.playerGold;
    }
}
