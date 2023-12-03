using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    public float Health = 100f;
    public float Damage ;
    public Material EnviRend;
    private Animator animator;
    
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Weapon"))
        {
            EnviRend.SetColor("_Color", Color.white);
            Debug.Log(Damage);
            Health = Health - Damage;
            if (Health <= 0)
            {
                animator.Play("Death");
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
