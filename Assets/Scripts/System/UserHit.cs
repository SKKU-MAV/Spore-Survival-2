using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserHit : MonoBehaviour
{
    [SerializeField]
    int hp = 100;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6 && other.gameObject.GetComponentInParent<Animator>().GetBool("isAttacking") == true)
        {
            if(hp > 0)
            {
                hp -= 20;
                Debug.Log($"User Hp : {hp}");
            }
            else if (hp <= 0)
            {
                Debug.Log("Die");
            }
        }
    }
}
