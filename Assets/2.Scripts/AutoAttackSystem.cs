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
            float attackInterval = 5f / PlayerStats.Instance.autoAttackSpeed; // �ӵ� �ݿ�
            yield return new WaitForSeconds(attackInterval);

            //  ���� baseDamage �� ��� �ݿ� (���׷��̵� ����)
            int damage = Mathf.RoundToInt(PlayerStats.Instance.baseDamage);
            int gold = Mathf.RoundToInt(10 * PlayerStats.Instance.goldBonus); // ��� ȹ�淮 �ݿ�

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
                // PlayerStats�� baseDamage�� �ݿ�
                float damage = PlayerStats.Instance.baseDamage;
                enemyScript.TakeDamage(damage);
                Debug.Log($"�ڵ� ����! {damage} ������");
            }
        }
    }


    private void GrantGold(int gold)
    {
        if (PlayerStats.Instance != null)
        {
            PlayerStats.Instance.playerData.AddGold(gold);
            UpgradeManager.Instance.UpdateGoldUI();
            Debug.Log($"�ڵ� ���� {gold} ��� ȹ��! ���� ���: {PlayerStats.Instance.playerData.gold}");
        }
        else
        {
            Debug.LogError("PlayerStats.Instance�� null�Դϴ�. ���� PlayerStats ������Ʈ�� �ִ��� Ȯ���ϱ�.");
        }
    }
}