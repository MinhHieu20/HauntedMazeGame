using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{

    private GameObject target;
    private NavMeshAgent agent;
    private Animator anim;

    private bool isWalking;
    private bool isRunning;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        WalkToRandomSpot();
    }

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, target.transform.position);
        if (distance <= 20)
        {
            ChasePlayer();
        }
        else if (isRunning)
        {
            WalkToRandomSpot();
        }
       
        if (distance <= 10)
        {
            anim.SetTrigger("attack");

        }
    }


    private void ChasePlayer()
    {
        agent.SetDestination(target.transform.position);
        if (!isRunning)
        {
            isRunning = true;
            isWalking = false;
            agent.speed = 2f;
            anim.SetBool("isRunning", isRunning);
            anim.SetBool("isWalking", isWalking);
        }
    }

    private void WalkToRandomSpot()
    {
        agent.speed = 1f;
        isRunning = false;
        isWalking = true;
        anim.SetBool("isRunning", isRunning);
        anim.SetBool("isWalking", isWalking);
    }
}