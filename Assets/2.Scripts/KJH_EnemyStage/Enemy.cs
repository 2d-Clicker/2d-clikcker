using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public EnemyData enemyData;
    public Image hpFillImage;
    public StageManager stageManager;   // Stage ���� �޾ƿ���

    [SerializeField] float maxHP;
    [SerializeField] float currentHP;
    [SerializeField] float dmg ;


    void Start()
    {
        Initialize();
    }
    public void Initialize()
    {
        if (enemyData == null || stageManager == null) return;

        // ü�� = baseHP �� ���� ��������
        maxHP = enemyData.baseHP * stageManager.currentStage;
        currentHP = maxHP;

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
        stageManager.StageCount();  // ������ �������� ���� ����
        Destroy(gameObject);
    }
}
