using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int stage = 1;
    public int gold = 1;
    public int criticalDamage = 10; // �⺻ 10%
    public float autoAttack = 0f; //�ڵ� ����
    public int goldBonus = 0; // ��� ���ʽ� ȹ��
    public int weaponAttack = 0; // ���� ���ݷ�
    public int weaponCriticalChance = 0; // ���� ġ��Ÿ Ȯ��
    
    public int FinalAttackPower() //���� ���ݷ�
    {
        return weaponAttack;
    }
    
    public int FinalCriticalDamage() // ���� ġ��Ÿ ������
    {
        return criticalDamage + weaponCriticalChance; //Ȯ�� üũ�� ���ݷ�������.
    }
    
    public int FinalGoldBonus() //���� ��� ���ʽ�
    {
        return goldBonus;
    }
}
