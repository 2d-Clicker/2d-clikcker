using UnityEngine;

[System.Serializable]
public class PlayerData
{
    //�÷��̾� ������ (ġ��Ÿ, ġ��Ÿ Ȯ��, ��� ȹ��)
    public int stage; // ���� �������� ��������
    public int coin; // ���� ��
    public int critical; // ġ��Ÿ
    public float criticalPro; // ġ��Ÿ Ȯ��
    public float goldBonus; // ��� ȹ�� ���ʽ�


    //���� ���� ���� ��� ()
    //public int FinalWeaponStat(int weaponstat)
    //{
    //    return weaponstat;
    //}

    //���� ���ݷ� ��� (�⺻ �÷��̾� ���ݷ� + ���׷��̵� �÷��̾� ���ݷ� + ���׷��̵� Į ���ݷ�)
    public int FinalAttack(int upgradeplayerstat, int weaponstat)
    {
        return critical + weaponstat + upgradeplayerstat;
    }

    //���� ġ��Ÿ Ȯ�� ��� (�⺻ ġ��Ÿ Ȯ�� + ���׷��̵� �÷��̾� ġ��Ÿ Ȯ�� + ���׷��̵� Į ġ��Ÿ Ȯ��)
    public float FinalCritical(float upgradeplayerstat, float upgradeweaponstat)
    {
        return criticalPro + upgradeweaponstat;
    }

    //���� ��� ȹ�� ���ʽ� ��� (�⺻ ��� ȹ�� ���ʽ� + ���׷��̵� �� Į ��� ȹ�� ���ʽ�)

}
