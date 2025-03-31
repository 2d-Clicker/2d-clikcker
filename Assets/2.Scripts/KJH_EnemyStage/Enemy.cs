using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public EnemyData enemyData;
    public Image hpFillImage;
    public StageManager stageManager;   // Stage 정보 받아오기

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

        // 체력 = baseHP × 현재 스테이지
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
        stageManager.StageCount();  // 죽으면 스테이지 라운드 증가
        Destroy(gameObject);
    }
}
