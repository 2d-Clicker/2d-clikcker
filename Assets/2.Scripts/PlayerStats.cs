using UnityEngine;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance;

    public float baseDamage = 10f; // 기본 공격력 추가
    public float criticalChance = 5f; // 치명타 확률 추가
    public float criticalDamage = 1f;
    public float autoAttackSpeed = 1f;
    public float goldBonus = 1f;

    public TextMeshProUGUI damageText;      // 기본 공격력 UI
    public TextMeshProUGUI criticalText;    // 치명타 확률 UI
    public TextMeshProUGUI criticalDmgText; // 치명타 데미지 UI
    public TextMeshProUGUI autoAttackText;  // 자동 공격 속도 UI
    public TextMeshProUGUI goldBonusText;   // 골드 보너스 UI

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
        if (damageText != null) damageText.text = $"기본 데미지: {baseDamage}";
        if (criticalText != null) criticalText.text = $"치명타 확률: {criticalChance}%";
        if (criticalDmgText != null) criticalDmgText.text = $"치명타 데미지: {criticalDamage}x";
        if (autoAttackText != null) autoAttackText.text = $"자동 공격 속도: {autoAttackSpeed}x";
        if (goldBonusText != null) goldBonusText.text = $"골드 획득량: {goldBonus}%";
    }

    public void ApplyUpgrade(string upgradeName, float newValue)
    {
        switch (upgradeName)
        {
            case "기본 데미지":
                baseDamage = newValue;
                break;
            case "치명타 확률":
                criticalChance = newValue;
                break;
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
