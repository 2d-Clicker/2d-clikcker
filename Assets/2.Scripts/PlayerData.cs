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

    // ������ ���� ����
    public bool hasBoughtKnifeGamja = false;
    public bool hasBoughtKnifeShort = false;
    public bool hasBoughtKnifeBread = false;
    public bool hasBoughtKnifeKitchen = false;
    public bool hasBoughtKnifeChef = false;

    public float CalculateFinalDamage() //����������
    {
        // �⺻ ������ ���
        float normalDamage = baseDamage + (attackUpgradeLevel * 5) + equippedWeaponAttack; //5�� �߰� ���ݷ�.�뷱�������� �����ϱ�

        // ġ��Ÿ Ȯ�� üũ (ġ��Ÿ Ȯ���� 0~100%)
        bool isCritical = Random.value < (FinalCritChance() / 100f);

        // ���� ������ ����
        float finalDamage = isCritical ? normalDamage * FinalCritDamage() : normalDamage;

        Debug.Log(isCritical ? $"ġ��Ÿ {finalDamage} ������" : $" �Ϲ� ���� {finalDamage} ������");
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
            Debug.Log($"��� ���: {amount} | ���� ���: {gold}");
            return true;
        }
        Debug.Log("��� ����! ���� �Ұ�.");
        return false;
    }

    public void AddGold(int amount)
    {
        gold = Mathf.Min(99999, gold + Mathf.RoundToInt(amount * FinalGoldBonus()));
    }

    // ���� ���� �� �÷��̾� ���� ������Ʈ
    public void EquipWeapon(WeaponStats newWeaponStats)
    {
        // ���� ������ ������ �ɷ�ġ�� ���� ���� ������ ������ �ɷ�ġ�� ����
        baseDamage += newWeaponStats.baseDamage;
        criticalChance += newWeaponStats.baseCritChance;
        criticalDamage += newWeaponStats.baseCritDamage;

        // ������ ���� �ɷ� ������Ʈ
        equippedWeaponAttack = newWeaponStats.baseDamage;
        equippedCritChance = newWeaponStats.baseCritChance;
        equippedCritDamage = newWeaponStats.baseCritDamage;

        // �α� ��� (����׿�)
        Debug.Log($"���� ���� �Ϸ�: {newWeaponStats.weaponName}");
        Debug.Log($"���� ���ݷ�: {baseDamage}, ���� ġ��Ÿ Ȯ��: {criticalChance}, ���� ġ��Ÿ ����: {criticalDamage}");
    }
}

