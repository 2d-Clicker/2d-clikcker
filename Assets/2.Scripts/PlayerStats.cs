using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance;  // �̱���

    public float criticalDamageMultiplier = 1.0f;  // ġ��Ÿ ���� (�⺻�� 100%)
    public float autoAttackSpeed = 1.0f;          // �ڵ� ���� �ӵ�
    public float goldBonusMultiplier = 1.0f;      // ��� ȹ�� ���� ����

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
        LoadStats(); // ���� ���� �� ����� �� �ҷ�����
    }

    public void ApplyUpgrade(string upgradeName, float value)
    {
        switch (upgradeName)
        {
            case "ġ��Ÿ ������":
                criticalDamageMultiplier += value;
                break;
            case "�ڵ� ����":
                autoAttackSpeed += value;
                break;
            case "��� ȹ��":
                goldBonusMultiplier += value;
                break;
        }
    }

    public void LoadStats()
    {
        criticalDamageMultiplier = PlayerPrefs.GetFloat("CriticalDamage", 1.0f);
        autoAttackSpeed = PlayerPrefs.GetFloat("AutoAttackSpeed", 1.0f);
        goldBonusMultiplier = PlayerPrefs.GetFloat("GoldBonus", 1.0f);
    }

    public void SaveStats()
    {
        PlayerPrefs.SetFloat("CriticalDamage", criticalDamageMultiplier);
        PlayerPrefs.SetFloat("AutoAttackSpeed", autoAttackSpeed);
        PlayerPrefs.SetFloat("GoldBonus", goldBonusMultiplier);
        PlayerPrefs.Save();
    }
}
