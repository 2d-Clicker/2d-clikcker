using UnityEngine;

public class ClickToDamage : MonoBehaviour
{
    public float clickDamage = 10f;


    public void DamageTaggedEnemy()
    {
        GameObject enemy = GameObject.FindWithTag("Enemy");
        if (enemy != null)
        {
            Enemy enemyScript = enemy.GetComponent<Enemy>();
            if (enemyScript != null)
            {
                enemyScript.TakeDamage(clickDamage);
            }
        }
    }
}
