using System.Collections;
using UnityEngine;

public class AutoAttackSystem : MonoBehaviour
{
    public static AutoAttackSystem Instance;

    private bool isAutoAttacking = false;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Start()
    {
        StartAutoAttack();
    }

    public void StartAutoAttack()
    {
        if (!isAutoAttacking && PlayerStats.Instance.autoAttackSpeed > 0)
        {
            isAutoAttacking = true;
            StartCoroutine(AutoAttackRoutine());
        }
    }

    private IEnumerator AutoAttackRoutine()
    {
        while (PlayerStats.Instance.autoAttackSpeed > 0)
        {
            float attackInterval = 5f / PlayerStats.Instance.autoAttackSpeed; // 속도 반영
            yield return new WaitForSeconds(attackInterval);

            //  현재 baseDamage 값 즉시 반영 (업그레이드 적용)
            int damage = Mathf.RoundToInt(PlayerStats.Instance.baseDamage);
            int gold = Mathf.RoundToInt(10 * PlayerStats.Instance.goldBonus); // 골드 획득량 반영

            ApplyDamage();
            GrantGold(gold);
        }
    }

    private void ApplyDamage()
    {
        GameObject enemy = GameObject.FindWithTag("Enemy");
        if (enemy != null)
        {
            Enemy enemyScript = enemy.GetComponent<Enemy>();
            if (enemyScript != null)
            {
                // PlayerStats의 baseDamage를 반영
                float damage = PlayerStats.Instance.baseDamage;
                enemyScript.TakeDamage(damage);
                Debug.Log($"자동 공격! {damage} 데미지");
            }
        }
    }


    private void GrantGold(int gold)
    {
        if (PlayerStats.Instance != null)
        {
            PlayerStats.Instance.playerData.AddGold(gold);
            UpgradeManager.Instance.UpdateGoldUI();
            Debug.Log($"자동 공격 {gold} 골드 획득! 현재 골드: {PlayerStats.Instance.playerData.gold}");
        }
        else
        {
            Debug.LogError("PlayerStats.Instance가 null입니다. 씬에 PlayerStats 오브젝트가 있는지 확인하기.");
        }
    }
}