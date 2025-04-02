using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public EnemyData enemyData;
    public Image hpFillImage;
    public StageManager stageManager;   // Stage ���� �޾ƿ���
    public EnemySpawner spawner;

    [SerializeField] float maxHP;
    [SerializeField] float currentHP;
    [SerializeField] int dropMoney;

    [SerializeField] float dmg ;


    public void Initialize()
    {
        // ü�� = baseHP �� ���� ��������
        maxHP = enemyData.baseHP * stageManager.currentStage;
        currentHP = maxHP;

        //��� ����
        dropMoney = enemyData.dropGold * stageManager.currentStage*3; 
        UpdateHPBar();
    }

    public void TakeDamage(float dmg)
    {
        
        currentHP -= dmg;
        if (currentHP < 0) currentHP = 0;

        UpdateHPBar();

        if (currentHP <= 0)
        {
            Die();
        }
    }
    void UpdateHPBar()
    {
        if (hpFillImage != null)
            hpFillImage.fillAmount = currentHP / maxHP;
    }
    void Die()
    {
        //��� ���޷���
        PlayerStats.Instance.playerData.AddGold(dropMoney);
        Debug.Log($"�� óġ! {dropMoney} ��� ȹ��. ���� ���: {PlayerStats.Instance.playerData.gold}");

        // ��� UI ������Ʈ �߰�
        GoldManager goldManager = GameObject.FindObjectOfType<GoldManager>();
        if (goldManager != null)
        {
            goldManager.UpdateGoldUI();
        }
        else
        {
            Debug.LogError("GoldManager�� ã�� �� �����ϴ� UI ������Ʈ ����");
        }

        stageManager.StageCount();  // ������ �������� ���� ����
        spawner.OnEnemyKilled();
        Destroy(gameObject);
    }
}
