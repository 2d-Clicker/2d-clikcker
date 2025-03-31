using UnityEngine;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance;

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
        UpdateStatsUI();
    }

    public void UpdateStatsUI()
    {
        if (damageText != null) damageText.text = $"�⺻ ������: {baseDamage}";
        if (criticalText != null) criticalText.text = $"ġ��Ÿ Ȯ��: {criticalChance}%";
        if (criticalDmgText != null) criticalDmgText.text = $"ġ��Ÿ ������: {criticalDamage}x";
        if (autoAttackText != null) autoAttackText.text = $"�ڵ� ���� �ӵ�: {autoAttackSpeed}x";
        if (goldBonusText != null) goldBonusText.text = $"��� ȹ�淮: {goldBonus}%";
    }

    public void ApplyUpgrade(string upgradeName, float newValue)
    {
        switch (upgradeName)
        {
            case "�⺻ ������":
                baseDamage = newValue;
                break;
            case "ġ��Ÿ Ȯ��":
                criticalChance = newValue;
                break;
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
