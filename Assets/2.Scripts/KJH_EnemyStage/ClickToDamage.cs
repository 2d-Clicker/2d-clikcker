using UnityEngine;

public class ClickToDamage : MonoBehaviour
{
    private GoldManager goldManager;

    public int clickGoldReward = 1; // 클릭시 +1골드
    private void Start()
    {
        goldManager = FindObjectOfType<GoldManager>(); // GoldManager 찾기
        if (goldManager == null)
        {
            Debug.LogError("GoldManager를 못찾았습니다. 씬에 GoldManager 오브젝트가 있는지 확인하세요.");
        }
        else
        {
            Debug.Log("GoldManager 정상적으로 할당됨.");
        }
    }
    public void ClickDamage()
    {
        GrantGold(clickGoldReward);

        GameObject enemy = GameObject.FindWithTag("Enemy");
        if (enemy != null)
        {
            Enemy enemyScript = enemy.GetComponent<Enemy>();
            if (enemyScript != null)
            {
                // PlayerData의  CalculateFinalDamage 반영
                float damage = PlayerStats.Instance.playerData.CalculateFinalDamage();
                enemyScript.TakeDamage(damage);
                Debug.Log($"클릭 {damage} 데미지");
            }
        }
    }
    private void GrantGold(int gold)
    {
        if (goldManager != null)
        {
            goldManager.GetGold(gold); // GoldManager를 통해 골드 추가
        }
    }
}
