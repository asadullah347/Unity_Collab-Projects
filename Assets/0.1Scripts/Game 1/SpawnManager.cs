using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;

    [SerializeField] float waitTime = 2f;
    //wave1~3: ( 10,-18 ), ( 10,-18)
    //    4~5: (-10, 0), (10, 0)
    int range = 15;

    void Start()
    {
        StartCoroutine(SpawnEnemy(waitTime, enemyPrefab));
    }

    IEnumerator SpawnEnemy(float waitT, GameObject enemy)
    {
        yield return new WaitForSeconds(waitT);
        GameObject newEnemy = Instantiate(enemy, new Vector3 (Random.Range(-range,range), 1 , Random.Range(-range,range)), Quaternion.identity);
        StartCoroutine(SpawnEnemy(waitTime, enemyPrefab));
    }
}
