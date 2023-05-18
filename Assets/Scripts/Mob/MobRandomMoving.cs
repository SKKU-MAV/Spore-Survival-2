using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MobRandomMoving : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent agent;

    [SerializeField]
    private Animator animator;

    private float move_x_pos;
    private float move_z_pos;
    // [SerializeField]
    // private float random_factor = 5f;

    Vector3 destination;
    float timer;
    int waitingTime;

    //추가
    public GameObject planeObject; //spawner
    BoxCollider rangeCollider;
    Vector3 originPosition;

    private void Awake()
    {
        timer = 0.0f;
        waitingTime = 5;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        destination = transform.position;

        //추가
        rangeCollider = planeObject.GetComponent<BoxCollider>();
        originPosition = planeObject.transform.position;
    }
    
    private void Update()
    {
        //목적지에 도착	
        if ((transform.position - agent.destination).magnitude < agent.stoppingDistance)
            {
                timer += Time.deltaTime;

                //추가
                float range_X = rangeCollider.bounds.size.x;
                float range_Z = rangeCollider.bounds.size.z;

                animator.SetBool("isWalking", false);
                move_x_pos = Random.Range( (range_X / 2) * -1, range_X / 2);
                move_z_pos = Random.Range((range_Z / 2) * -1, range_Z / 2);
                Vector3 RandomPostion = new Vector3(move_x_pos, 0, move_z_pos); //랜덤 포지션


                //목적지를 갱신
                if(timer > waitingTime)
                {
                    destination = originPosition + RandomPostion; //spawner의 원래 위치와 이동할 위치를 더해서 destination 정하기
                    agent.SetDestination(destination);
                    animator.SetBool("isWalking", true);
                    timer = 0;
                }
               
            }


    }




}
