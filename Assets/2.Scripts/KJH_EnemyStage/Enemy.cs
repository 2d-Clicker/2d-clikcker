using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public EnemyData enemyData;
    public Image hpFillImage;
    public StageManager stageManager;   // Stage 정보 받아오기
    public EnemySpawner spawner;

    [SerializeField] float maxHP;
    [SerializeField] float currentHP;
    [SerializeField] int dropMoney;

    [SerializeField] float dmg ;


    public void Initialize()
    {
        // 체력 = baseHP × 현재 스테이지
        maxHP = enemyData.baseHP * stageManager.currentStage;
        currentHP = maxHP;

        //골드 보상
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
        //골드 지급로직
        PlayerStats.Instance.playerData.AddGold(dropMoney);
        Debug.Log($"적 처치! {dropMoney} 골드 획득. 현재 골드: {PlayerStats.Instance.playerData.gold}");

        // 골드 UI 업데이트 추가
        GoldManager goldManager = GameObject.FindObjectOfType<GoldManager>();
        if (goldManager != null)
        {
            goldManager.UpdateGoldUI();
        }
        else
        {
            Debug.LogError("GoldManager를 찾을 수 없습니다 UI 업데이트 실패");
        }

        stageManager.StageCount();  // 죽으면 스테이지 라운드 증가
        spawner.OnEnemyKilled();
        Destroy(gameObject);
    }
}
