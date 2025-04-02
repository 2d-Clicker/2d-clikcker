using UnityEngine;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour
{
    public Transform spawnParent;
    public StageManager stageManager;

    public GameObject strawberryPrefab;
    public GameObject lemonPrefab;
    public GameObject orangePrefab;
    public GameObject applePrefab;
    public GameObject pineapplePrefab;



    private List<GameObject> spawnList = new List<GameObject>();
    private GameObject currentEnemy;

    void Start()
    {
        SetupStage();
        SpawnNext();
    }

    public void SetupStage()// 스테이지별 나오는 적 설정
    {
        spawnList.Clear();
        int stage = stageManager.currentStage;

        if (stage == 1)
        {
            AddPrefabs(strawberryPrefab, 10);
        }
        else if (stage == 2)
        {
            AddPrefabs(strawberryPrefab, 5);
            AddPrefabs(lemonPrefab, 5);
        }
        else if (stage == 3)
        {
            AddPrefabs(strawberryPrefab, 3);
            AddPrefabs(lemonPrefab, 3);
            AddPrefabs(orangePrefab, 4);
        }

        else if (stage == 4)
        {
            AddPrefabs(strawberryPrefab, 2);
            AddPrefabs(lemonPrefab, 2);
            AddPrefabs(orangePrefab, 3);
            AddPrefabs(applePrefab, 3);
        }

        else if (stage == 5)
        {
            AddPrefabs(strawberryPrefab, 2);
            AddPrefabs(lemonPrefab, 2);
            AddPrefabs(orangePrefab, 2);
            AddPrefabs(applePrefab, 2);
            AddPrefabs(pineapplePrefab, 2);
        }
        Shuffle(spawnList); 
    }

    void AddPrefabs(GameObject prefab, int count) //스테이지에 넣을 적을 매개변수로 투입
    {
        for (int i = 0; i < count; i++)
        {
            spawnList.Add(prefab);
        }
    }

    public void SpawnNext() //리스트의 다음적을 생성하는 메서드 
    {
        if (spawnList.Count == 0)
        {
            SetupStage();
        }

        if (currentEnemy != null)
            Destroy(currentEnemy);

        GameObject next = spawnList[0];
        spawnList.RemoveAt(0);

        currentEnemy = Instantiate(next, spawnParent.position, Quaternion.identity, spawnParent);
        Enemy enemyScript = currentEnemy.GetComponent<Enemy>();
        enemyScript.spawner = this;
        enemyScript.stageManager = stageManager;
        enemyScript.Initialize();
    }

    public void OnEnemyKilled() //적이 죽었을 때 호출할 메서드
    {
        SpawnNext();
    }

    void Shuffle(List<GameObject> list) //배치된 리스트에서 순서를 무작위로 배치하는 기능
    {
        for (int i = 0; i < list.Count; i++)
        {
            int rand = Random.Range(i, list.Count);
            GameObject temp = list[i];
            list[i] = list[rand];
            list[rand] = temp;
        }
    }
}
