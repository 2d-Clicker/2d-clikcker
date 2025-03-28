using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public Image bodyImage;     // 과일 이미지
    public Image hpFillImage;   // 체력바 Fill

    private float maxHP;
    private float currentHP;

    public void Initialize(EnemyData data)
    {
        maxHP = data.baseHP;
        currentHP = maxHP;
        bodyImage.sprite = data.enemyImage;
        UpdateHPBar();
    }
    public void TakeDamage(float damage)
    {
        currentHP -= damage;
        if (currentHP <= 0) currentHP = 0;
        UpdateHPBar();
        if (currentHP <= 0)
        {
            Destroy(gameObject);
        }
    }
    void UpdateHPBar()
    {
        if (hpFillImage != null)
            hpFillImage.fillAmount = currentHP / maxHP;
    }
}
