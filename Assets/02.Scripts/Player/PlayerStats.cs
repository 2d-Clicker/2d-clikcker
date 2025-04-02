using TMPro;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance;
    public PlayerData playerData;

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
        if (playerData == null)
            playerData = new PlayerData();
        UpdateStatsUI();
    }

    public void UpdateStatsUI()
    {
        if (playerData == null) return; //playerdata가 없으면 실행x

        if (damageText != null) damageText.text = $"기본 데미지: {playerData.CalculateFinalDamage()}";
        if (criticalText != null) criticalText.text = $"치명타 확률: {playerData.FinalCritChance()}%";
        if (criticalDmgText != null) criticalDmgText.text = $"치명타 데미지: {playerData.FinalCritDamage()}x";
        if (autoAttackText != null) autoAttackText.text = $"자동 공격 속도: {playerData.FinalAutoAttack()}x";
        if (goldBonusText != null) goldBonusText.text = $"골드 획득량: {playerData.FinalGoldBonus()}";
    }

    public void ApplyUpgrade(string upgradeName, float newValue)
    {
        switch (upgradeName)
        {
            case "기본 데미지":
                playerData.baseDamage = newValue;
                break;
            case "치명타 확률":
                playerData.criticalChance = newValue;
                break;
            case "치명타 데미지":
                playerData.criticalDamage = newValue;
                break;
            case "자동공격":
                autoAttackSpeed = newValue; 
                AutoAttackSystem.Instance.UpdateAutoAttackSpeed(); 
                break;
            case "재화 획득량 증가":
                playerData.goldBonus = newValue;
                break;
        }

        UpdateStatsUI();
    }

}

