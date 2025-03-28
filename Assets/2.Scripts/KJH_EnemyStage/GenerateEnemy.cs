using UnityEngine;

public class GenerateEnemy : MonoBehaviour
{
    public RectTransform spawnParent; // Canvas �ȿ� ���� ���� �θ�
    public GameObject enemyUIPrefab; // ApplePrefab ��
    public EnemyData enemyData;

    public Enemy currentEnemy;

    void Start()
    {
        SpawnEnemy();
    }

    public void SpawnEnemy()
    {
        if (currentEnemy != null)
            Destroy(currentEnemy.gameObject);

        GameObject enemyUI = Instantiate(enemyUIPrefab, spawnParent);
        currentEnemy = enemyUI.GetComponent<Enemy>();
        currentEnemy.Initialize(enemyData);
    }
}