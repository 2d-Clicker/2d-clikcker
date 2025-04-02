using TMPro;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance;
    public PlayerData playerData;

    public float baseDamage = 10f; // �⺻ ���ݷ� �߰�
    public float criticalChance = 5f; // ġ��Ÿ Ȯ�� �߰�
    public float criticalDamage = 1f;
    public float autoAttackSpeed = 1f;
    public float goldBonus = 1f;

    public TextMeshProUGUI damageText;      // �⺻ ���ݷ� UI
    public TextMeshProUGUI criticalText;    // ġ��Ÿ Ȯ�� UI
    public TextMeshProUGUI criticalDmgText; // ġ��Ÿ ������ UI
    public TextMeshProUGUI autoAttackText;  // �ڵ� ���� �ӵ� UI
    public TextMeshProUGUI goldBonusText;   // ��� ���ʽ� UI

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
        if (playerData == null) return; //playerdata�� ������ ����x

        if (damageText != null) damageText.text = $"�⺻ ������: {playerData.CalculateFinalDamage()}";
        if (criticalText != null) criticalText.text = $"ġ��Ÿ Ȯ��: {playerData.FinalCritChance()}%";
        if (criticalDmgText != null) criticalDmgText.text = $"ġ��Ÿ ������: {playerData.FinalCritDamage()}x";
        if (autoAttackText != null) autoAttackText.text = $"�ڵ� ���� �ӵ�: {playerData.FinalAutoAttack()}x";
        if (goldBonusText != null) goldBonusText.text = $"��� ȹ�淮: {playerData.FinalGoldBonus()}";
    }

    public void ApplyUpgrade(string upgradeName, float newValue)
    {
        switch (upgradeName)
        {
            case "�⺻ ������":
                playerData.baseDamage = newValue;
                break;
            case "ġ��Ÿ Ȯ��":
                playerData.criticalChance = newValue;
                break;
            case "ġ��Ÿ ������":
                playerData.criticalDamage = newValue;
                break;
            case "�ڵ�����":
                autoAttackSpeed = newValue; 
                AutoAttackSystem.Instance.UpdateAutoAttackSpeed(); 
                break;
            case "��ȭ ȹ�淮 ����":
                playerData.goldBonus = newValue;
                break;
        }

        UpdateStatsUI();
    }

}

