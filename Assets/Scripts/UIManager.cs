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
        UpdateUI();  // ������ �� UI ����
    }

    public void UpdateUI()
    {
        goldText.text = "���: " + UpgradeManager.Instance.playerGold;
    }
}
