using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance;  // 싱글톤

    public float criticalDamageMultiplier = 1.0f;  // 치명타 배율 (기본값 100%)
    public float autoAttackSpeed = 1.0f;          // 자동 공격 속도
    public float goldBonusMultiplier = 1.0f;      // 골드 획득 증가 배율

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
        LoadStats(); // 게임 시작 시 저장된 값 불러오기
    }

    public void ApplyUpgrade(string upgradeName, float value)
    {
        switch (upgradeName)
        {
            case "치명타 데미지":
                criticalDamageMultiplier += value;
                break;
            case "자동 공격":
                autoAttackSpeed += value;
                break;
            case "골드 획득":
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
