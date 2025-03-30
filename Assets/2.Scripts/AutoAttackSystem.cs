using System.Collections;
using System.Collections.Generic;
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
            float attackInterval = 1f / PlayerStats.Instance.autoAttackSpeed; // 속도 반영
            yield return new WaitForSeconds(attackInterval);

            int damage = Mathf.RoundToInt(PlayerStats.Instance.baseDamage * PlayerStats.Instance.autoAttackSpeed);
            int gold = Mathf.RoundToInt(10 * PlayerStats.Instance.goldBonus); // 골드 획득량 반영

            ApplyDamage(damage);
            GrantGold(gold);
        }
    }

    private void ApplyDamage(int damage)
    {
        Debug.Log($" 자동 공 {damage} 데미지.");

    }

    private void GrantGold(int gold)
    {
        UpgradeManager.Instance.playerGold += gold;
        UpgradeManager.Instance.UpdateGoldUI();
        Debug.Log($" 자동 공격 {gold} 골드");
    }
}
