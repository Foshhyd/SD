using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnimEnemyController : MonoBehaviour
{
    public GameObject PSLightning;
    private Animator anim;
    private Vector3 PlayerPos = new Vector3(0, 0, 0);
    private NavMeshAgent agent;
    private Quaternion PSRotation;

    //Variables
    private bool bTeleport = true;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        PSRotation = new Quaternion(0, 90f, 90f, 1f);
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
            Instantiate(PSLightning, this.transform.position, PSRotation);
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
