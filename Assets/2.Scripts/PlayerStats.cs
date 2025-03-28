using UnityEngine;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance;

    public float criticalDamage = 1f;
    public float autoAttackSpeed = 1f;
    public float goldBonus = 1f;

    public TextMeshProUGUI criticalText;
    public TextMeshProUGUI autoAttackText;
    public TextMeshProUGUI goldBonusText;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    void Start()
    {
        UpdateStatsUI();
    }

    public void UpdateStatsUI()
    {
        if (criticalText != null) criticalText.text = $"ġ��Ÿ ������: {criticalDamage}%";
        if (autoAttackText != null) autoAttackText.text = $"�ڵ� ���� �ӵ�: {autoAttackSpeed}x";
        if (goldBonusText != null) goldBonusText.text = $"��� ȹ�淮: {goldBonus}%";
    }

    public void ApplyUpgrade(string upgradeName, float newValue)
    {
  
        switch (upgradeName)
        {
            case "ġ��Ÿ ������":
                criticalDamage = newValue;
                break;
            case "�ڵ�����":
                autoAttackSpeed = newValue;
                break;
            case "��ȭ ȹ�淮 ����":
                goldBonus = newValue;
                break;
        }

        UpdateStatsUI();
    }


}
