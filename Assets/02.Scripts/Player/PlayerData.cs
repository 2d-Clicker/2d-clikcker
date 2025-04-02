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

    // 아이템 구매 여부
    public bool hasBoughtKnifeGamja = false;
    public bool hasBoughtKnifeShort = false;
    public bool hasBoughtKnifeBread = false;
    public bool hasBoughtKnifeKitchen = false;
    public bool hasBoughtKnifeChef = false;

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
            Debug.Log($"골드 사용: {amount} | 남은 골드: {gold}");
            return true;
        }
        Debug.Log("골드 부족! 구매 불가.");
        return false;
    }

    public void AddGold(int amount)
    {
        gold = Mathf.Min(99999, gold + Mathf.RoundToInt(amount * FinalGoldBonus()));
    }

    // 무기 장착 시 플레이어 스탯 업데이트
    public void EquipWeapon(WeaponStats newWeaponStats)
    {
        // 기존 장착된 무기의 능력치를 빼고 새로 장착한 무기의 능력치를 더함
        baseDamage += newWeaponStats.baseDamage;
        criticalChance += newWeaponStats.baseCritChance;
        criticalDamage += newWeaponStats.baseCritDamage;

        // 장착된 무기 능력 업데이트
        equippedWeaponAttack = newWeaponStats.baseDamage;
        equippedCritChance = newWeaponStats.baseCritChance;
        equippedCritDamage = newWeaponStats.baseCritDamage;

        // 로그 출력 (디버그용)
        Debug.Log($"무기 장착 완료: {newWeaponStats.weaponName}");
        Debug.Log($"최종 공격력: {baseDamage}, 최종 치명타 확률: {criticalChance}, 최종 치명타 배율: {criticalDamage}");
    }
}

