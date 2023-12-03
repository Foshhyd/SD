using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject EnemyObject;
    public int EnemyCount;
    private Quaternion EnemyRotation = new Quaternion(0.00f, 0.00f, 0.00f, 1.00f);
    private Vector3 PlayerPos = new Vector3(0, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnSys());
        StopCoroutine(SpawnSys());
    }

    IEnumerator SpawnSys()
    {
        while(EnemyCount > 0)
        {
            Vector3 EnemyPosition = new Vector3(Random.Range(-25f, 25f), -1.8f, Random.Range(-25f, 25f));
            Vector3 relativePos = PlayerPos - EnemyPosition;
            Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
            EnemyRotation = rotation;
            Instantiate(EnemyObject, EnemyPosition, EnemyRotation);
            EnemyCount--;
        }
        yield return null;
    }
}
