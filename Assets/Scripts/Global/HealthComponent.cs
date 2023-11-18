using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    public float Health = 100f;
    public float Damage ;
    public Material EnviRend;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Weapon"))
        {
            EnviRend.SetColor("_Color", Color.white);
            Health = Health - Damage;
            if (Health <= 0)
            {
                Destroy(gameObject, 3);
                if (EnviRend != null)
                {
                    EnviRend.SetColor("_Color", Color.black);
                    StartCoroutine(DeathEffect());
                }
            }
            
        }
    }
    IEnumerator DeathEffect()
    {
        yield return new WaitForSeconds(1f);
        EnviRend.SetColor("_Color", Color.white);
    }
}
