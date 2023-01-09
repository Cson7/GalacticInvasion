using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject Missiles;
    [SerializeField]
    private float Enemy1Interval = 1.5f;

    
    // Start is called before the first frame update
    void Start() 
    {
        StartCoroutine(spawnEnemy(Enemy1Interval, Missiles));
    }

    private IEnumerator spawnEnemy (float interval, GameObject Missiles)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(Missiles, new Vector3(Random.Range(0f, 4.5f), Random.Range(8.5f, 8.9f), 0), Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, Missiles));
    }
    public void DestroyThings (GameObject EnemySpawner)
    {
        Destroy(EnemySpawner,45);
    }
}