using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnimEnemyController : MonoBehaviour
{
    private Animator anim;
    private Vector3 PlayerPos = new Vector3(0, 0, 0);
    private NavMeshAgent agent;

    //Variables
    private bool bTeleport = true;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(anim.GetCurrentAnimatorStateInfo(0).IsTag("Walk"))
        {
            agent.SetDestination(PlayerPos);
            bTeleport = true;
        }
        else if(anim.GetCurrentAnimatorStateInfo(0).IsTag("Attack"))
        {
            if(bTeleport)
            {
                bTeleport = false;
                Teleport();
            }
            agent.SetDestination(this.transform.position);
        }
        else if(anim.GetCurrentAnimatorStateInfo(0).IsTag("Death"))
        {
            agent.SetDestination(this.transform.position);
        }
    }

    void Teleport()
    {
        Vector3 EnemyPosition = new Vector3(Random.Range(-25f, 25f), -1.8f, Random.Range(-25f, 25f));
        this.transform.position = EnemyPosition;
        Vector3 relativePos = PlayerPos - EnemyPosition;
        Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
        this.transform.rotation = rotation;
    }
}
