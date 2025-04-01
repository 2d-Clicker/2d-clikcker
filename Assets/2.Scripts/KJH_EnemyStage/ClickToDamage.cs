using UnityEngine;

public class ClickToDamage : MonoBehaviour
{
 
    public void ClickDamage()
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
                Debug.Log($"Ŭ�� {damage} ������");
            }
        }
    }
}
