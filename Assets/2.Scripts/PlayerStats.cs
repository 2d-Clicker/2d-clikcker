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
        if (criticalText != null) criticalText.text = $"치명타 데미지: {criticalDamage}%";
        if (autoAttackText != null) autoAttackText.text = $"자동 공격 속도: {autoAttackSpeed}x";
        if (goldBonusText != null) goldBonusText.text = $"골드 획득량: {goldBonus}%";
    }

    public void ApplyUpgrade(string upgradeName, float newValue)
    {
  
        switch (upgradeName)
        {
            case "치명타 데미지":
                criticalDamage = newValue;
                break;
            case "자동공격":
                autoAttackSpeed = newValue;
                break;
            case "재화 획득량 증가":
                goldBonus = newValue;
                break;
        }

        UpdateStatsUI();
    }


}
