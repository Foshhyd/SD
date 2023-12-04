using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthComponent : MonoBehaviour
{
    public float Health = 100f;
    public float Damage;
    public Material EnviRend;
    public string LayerName;
    public string SceneName;
    private Animator animator;
    
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Weapon") && LayerMask.NameToLayer("Weapon") == LayerMask.NameToLayer(LayerName))
        {
            EnviRend.SetColor("_Color", Color.white);
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
        else if(collision.gameObject.layer == LayerMask.NameToLayer("EWeapon") && LayerMask.NameToLayer("EWeapon") == LayerMask.NameToLayer(LayerName))
        {
            Health = Health - Damage;
            if (Health <= 0)
            {
                this.gameObject.SetActive(false);
                SceneManager.LoadScene(SceneName);
            }
        }
    }
    IEnumerator DeathEffect()
    {
        yield return new WaitForSeconds(1f);
        EnviRend.SetColor("_Color", Color.white);
    }
}
