using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int currentStage = 1;
    public int gold = 0;

    public float baseDamage = 10f; // �⺻ ���ݷ� �߰�
    public float criticalChance = 5f; // ġ��Ÿ Ȯ�� �߰�
    public float criticalDamage = 1f;
    public float autoAttackSpeed = 1f;
    public float goldBonus = 1f;

    public int attackUpgradeLevel = 0;
    public int goldBonusUpgradeLevel = 0;

    // ��� ȿ��
    public int equippedWeaponAttack = 0;
    public float equippedCritChance = 0;
    public float equippedCritDamage = 0;
    public float equippedGoldBonus = 0;

    public float FinalAutoAttack()
    {
        return autoAttackSpeed + (attackUpgradeLevel * 0.05f);
    }
    public float FinalAttackPower()
    {
        return baseDamage + (attackUpgradeLevel * 5) + equippedWeaponAttack;
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
