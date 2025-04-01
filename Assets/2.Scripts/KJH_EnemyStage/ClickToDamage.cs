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
                // PlayerStats의 baseDamage를 반영
                float damage = PlayerStats.Instance.baseDamage;
                enemyScript.TakeDamage(damage);
                Debug.Log($"클릭 {damage} 데미지");
            }
        }
    }
}
