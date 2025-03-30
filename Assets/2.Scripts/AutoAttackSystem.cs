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
            float attackInterval = 1f / PlayerStats.Instance.autoAttackSpeed; // �ӵ� �ݿ�
            yield return new WaitForSeconds(attackInterval);

            int damage = Mathf.RoundToInt(PlayerStats.Instance.baseDamage * PlayerStats.Instance.autoAttackSpeed);
            int gold = Mathf.RoundToInt(10 * PlayerStats.Instance.goldBonus); // ��� ȹ�淮 �ݿ�

            ApplyDamage(damage);
            GrantGold(gold);
        }
    }

    private void ApplyDamage(int damage)
    {
        Debug.Log($" �ڵ� �� {damage} ������.");

    }

    private void GrantGold(int gold)
    {
        UpgradeManager.Instance.playerGold += gold;
        UpgradeManager.Instance.UpdateGoldUI();
        Debug.Log($" �ڵ� ���� {gold} ���");
    }
}
