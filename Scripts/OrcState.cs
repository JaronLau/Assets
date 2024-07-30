using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class OrcState : MonoBehaviour
{
    public Animator animator;
    public NavMeshAgent agent;
    public Transform player;
    public Transform self;

    public float detectionRadius = 10f;
    public float attackRadius = 2f;
    public float attackCooldown = 4f;

    [Header("Idle state parameters")]
    public float idleWalkTime = 5f;
    public float idleWalkRadius = 5f;

    private float idleWalkTimer;
    private float lastAttackTime;
    private string currentState;
    private Vector3 idleDestination;

    public GameObject attackHitBox;

    void Start()
    {
        currentState = "Idle";
        ChangeState("Idle");
        idleWalkTimer = idleWalkTime;
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        //Debug.Log(distanceToPlayer + "," + self.position);

        if (distanceToPlayer <= attackRadius)
        {
            Debug.Log("in range");
            Attack();
        }
        else if (distanceToPlayer <= detectionRadius)
        {
            Debug.Log("Detected");
            agent.SetDestination(player.position);
            ChangeState("Chase");
        }
        else if (distanceToPlayer > detectionRadius)
        {
            ChangeState("Idle");
        }
        else if (currentState == "Attack1" || currentState == "Attack2")
        {
            // Let the attack coroutine handle state changes
        }
        else
        {
            IdleState();
        }
    }

    void MoveTowardsPlayer()
    {
        agent.SetDestination(player.position);
    }

    void Attack()
    {
        if (Time.time >= lastAttackTime + attackCooldown)
        {
            lastAttackTime = Time.time;
            StartCoroutine(AttackSequence());
        }
    }

    IEnumerator AttackSequence()
    {
        ChangeState("Attack1");
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
        ChangeState("Attack2");
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
        ChangeState("Idle");
    }

    private void IdleState()
    {
        if (idleWalkTimer <= 0)
        {
            Vector3 randomDirection = Random.insideUnitSphere * idleWalkRadius;
            randomDirection += transform.position;
            NavMeshHit hit;
            NavMesh.SamplePosition(randomDirection, out hit, idleWalkRadius, 1);
            idleDestination = hit.position;

            agent.SetDestination(idleDestination);
            ChangeState("IdleWalk");

            idleWalkTimer = idleWalkTime;
        }
        else if (agent.remainingDistance <= agent.stoppingDistance && !agent.pathPending)
        {
            ChangeState("Idle");
        }

        idleWalkTimer -= Time.deltaTime;
    }

    private void ChangeState(string newState, float crossfade = 0.2f)
    {
        if (currentState != newState)
        {
            currentState = newState;
            animator.CrossFade(newState, crossfade);
            Debug.Log("Changed state to: " + newState);

            switch (newState)
            {
                case "Idle":
                agent.ResetPath();
                break;
                case "Chase":
                agent.SetDestination(player.position);
                break;
                case "Attack1":
                case "Attack2":
                agent.ResetPath();
                break;
                case "IdleWalk":
                // No specific action needed
                break;
            }
        }
    }
}