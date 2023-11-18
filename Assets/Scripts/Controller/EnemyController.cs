using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    //public GameObject Player;
    public GameObject Enemy;
    //private Transform Target;
    private Vector3 PlayerPos = new Vector3 (0, 0, 0);
    private NavMeshAgent agent;
    private Animator animator;
    private float timer;
    private bool teleport;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        //Target = Player.transform;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (agent != null)
        {
            timer += Time.deltaTime;
            Walk();
            if(teleport)
            {
                TeleportEnemy();
            }
        }
    }

    void Walk()
    {
        teleport = false;
        if (timer > 2.5)        
        {
            agent.SetDestination(PlayerPos);
            timer = 0;
            teleport = true;
        }
    }

    void TeleportEnemy()
    {
        if (timer > 2.5)
        {
            Debug.Log("Teleport");
            animator.SetBool("Attack", true);
            teleport=false;
            timer = 0;
        }
    }
}
