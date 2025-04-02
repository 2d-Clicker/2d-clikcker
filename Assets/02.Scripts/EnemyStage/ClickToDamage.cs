using UnityEngine;

public class ClickToDamage : MonoBehaviour
{
    private GoldManager goldManager;

    public int clickGoldReward = 1; // Ŭ���� +1���
    private void Start()
    {
        goldManager = FindObjectOfType<GoldManager>(); // GoldManager ã��
        if (goldManager == null)
        {
            Debug.LogError("GoldManager�� ��ã�ҽ��ϴ�. ���� GoldManager ������Ʈ�� �ִ��� Ȯ���ϼ���.");
        }
        else
        {
            Debug.Log("GoldManager ���������� �Ҵ��.");
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
                // PlayerData��  CalculateFinalDamage �ݿ�
                float damage = PlayerStats.Instance.playerData.CalculateFinalDamage();
                enemyScript.TakeDamage(damage);
                Debug.Log($"Ŭ�� {damage} ������");
            }
        }
    }
    private void GrantGold(int gold)
    {
        if (goldManager != null)
        {
            goldManager.GetGold(gold); // GoldManager�� ���� ��� �߰�
        }
    }
}
