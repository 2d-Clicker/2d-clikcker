using UnityEngine;

public class ClickToDamage : MonoBehaviour
{
    [SerializeField] float clickDamage;


    public void ClickDamage()
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
