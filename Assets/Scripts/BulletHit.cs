using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHit : MonoBehaviour
{
    public float Life;
    //public LayerMask EnemyLM;
    
    void Awake()
    {
        Destroy(gameObject, Life);
    }

    void OnCollisionEnter(Collision collision)
    {
        //Destroy Collided object and Bullet
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            //Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
