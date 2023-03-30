using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MobHit: MonoBehaviour
{

    [SerializeField]
    GameObject dropitem;

    [SerializeField]
    float dieingTime = 1.5f;

    [SerializeField]
    private float hp = 100f;

    bool isHit = false;
    bool isPlayingDest = false;

    MobRandomMoving mobRandomMoving;
    NavMeshAgent agent;
    Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        mobRandomMoving = GetComponent<MobRandomMoving>();
        agent = GetComponent<NavMeshAgent>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Weapon"))
        {

            if (!isHit)
            {
                if(hp > 0)
                {
                    anim.Play("GetHit");
                    hp -= 20;
                }
                

            }



            Debug.Log($"Hp : {hp}");

            if ( hp <= 0)
            {
                mobRandomMoving.enabled = false;
                anim.Play("Die");
                if (!isPlayingDest)
                {
                    Invoke("DestroyMob", dieingTime);
                    isPlayingDest = true;
                    
                }
                    
            }

            isHit = true;

        }

    }


    private void OnTriggerExit(Collider other)
    {
        isHit = false;

    }

    private void DestroyMob()
    {
        Destroy(gameObject);
        Instantiate(dropitem, transform.position, transform.rotation);
    }

  

    

}
