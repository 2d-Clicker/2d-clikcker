using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int currentStage = 1;
    public int gold = 0;

    public float baseDamage = 10f; // 기본 공격력 추가
    public float criticalChance = 5f; // 치명타 확률 추가
    public float criticalDamage = 1f;
    public float autoAttackSpeed = 1f;
    public float goldBonus = 1f;

    public int attackUpgradeLevel = 0;
    public int goldBonusUpgradeLevel = 0;

    // 장비 효과
    public int equippedWeaponAttack = 0;
    public float equippedCritChance = 0;
    public float equippedCritDamage = 0;
    public float equippedGoldBonus = 0;

    public float CalculateFinalDamage() //최종데미지
    {
        // 기본 데미지 계산
        float normalDamage = baseDamage + (attackUpgradeLevel * 5) + equippedWeaponAttack; //5는 추가 공격력.밸런스조정때 수정하기

        // 치명타 확률 체크 (치명타 확률은 0~100%)
        bool isCritical = Random.value < (FinalCritChance() / 100f);

        // 최종 데미지 적용
        float finalDamage = isCritical ? normalDamage * FinalCritDamage() : normalDamage;

        Debug.Log(isCritical ? $"치명타 {finalDamage} 데미지" : $" 일반 공격 {finalDamage} 데미지");
        return finalDamage;
    }
    public float FinalAutoAttack()
    {
        return autoAttackSpeed + (attackUpgradeLevel * 0.05f);
    }

    public float FinalCritChance()
    {
        return (criticalChance + (attackUpgradeLevel * 0.01f) + equippedCritChance)*100;
    }

    public float FinalCritDamage()
    {
        return criticalDamage + (attackUpgradeLevel * 0.1f) + equippedCritDamage;
    }

    public float FinalGoldBonus()
    {
        return goldBonus + (goldBonusUpgradeLevel * 0.05f) + equippedGoldBonus;
    }

    public bool SpendGold(int amount)
    {
        if (gold >= amount)
        {
            gold -= amount;
            return true;
        }
        return false;
    }

    public void AddGold(int amount)
    {
        gold += Mathf.RoundToInt(amount * FinalGoldBonus());
    }
}
