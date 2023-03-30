using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MobAttack : MonoBehaviour
{
    NavMeshAgent agent;
    Animator animator;

    [SerializeField]
    GameObject targetObject;
    Transform target;
    [SerializeField]
    float chaseRange = 5f;
    [SerializeField]
    float turnSpeed = 5f;

    float distanceToTarget = Mathf.Infinity;
    bool isProvoked = false;
    


    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        targetObject = GameObject.Find("XR Origin");
        target = targetObject.transform;
        
    }

    private void Update()
    {
        distanceToTarget = Vector3.Distance(transform.position, target.position);

        if (isProvoked)
        {
            EngageTarget();
        }
        else if(chaseRange >= distanceToTarget)
        {
            isProvoked = true;
        }
    }

    public void OnDamageTaken()
    {
        isProvoked = true;
    }

    private void EngageTarget()
    {
        FaceTarget();

        if(distanceToTarget >= agent.stoppingDistance)
        {
            ChaseTarget();       
        }

        if(distanceToTarget <= agent.stoppingDistance) 
        {
            AttackTarget();
        }
    }

    private void ChaseTarget() {
        animator.SetBool("isAttacking", false);
        animator.SetBool("isRunning",true);
        agent.SetDestination(target.position);
    }

    private void AttackTarget() {
        animator.SetBool("isAttacking", true);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }

    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }

}
