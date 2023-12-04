
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EBulletSpawn : MonoBehaviour
{
    public GameObject BulletObject;
    public GameObject SpawnPoint;
    public float BulletSpeed;

    void SpawnBulletEvent()
    {
        BulletSpawn();
    }

    private void BulletSpawn()
    {
        var Bullet = Instantiate(BulletObject, SpawnPoint.transform.position, SpawnPoint.transform.rotation);
        Bullet.GetComponent<Rigidbody>().velocity = SpawnPoint.transform.forward * BulletSpeed;
    }
}
