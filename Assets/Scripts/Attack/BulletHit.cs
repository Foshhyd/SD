using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHit : MonoBehaviour
{
    public float Life;
    public string LayerName;
    
    void Awake()
    {
        Destroy(gameObject, Life);
    }

    void OnCollisionEnter(Collision collision)
    {
        //Destroy Collided object and Bullet
        if (collision.gameObject.layer == LayerMask.NameToLayer(LayerName))
        {
            Destroy(gameObject);
        }
    }
}
