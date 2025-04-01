using UnityEngine;
using UnityEngine.UI;

public class GenerateEnemyTest : MonoBehaviour
{
    public RectTransform spawnParent; // Canvas 안에 적을 넣을 부모
    public GameObject enemyUIPrefab; // ApplePrefab 등
    public EnemyData enemyData;
    public HandleAttack handleAttack;
    public Image hpFill;

    [HideInInspector] public Enemy currentEnemy;

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
        currentEnemy.Initialize();
        currentEnemy.hpFillImage = hpFill;
        handleAttack.enemy = currentEnemy;
    }
}