using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPfacePlayer : MonoBehaviour
{
    [SerializeField]
    Transform target;

    // Update is called once per frame
    private void Update()
    {
        FaceTarget();
    }

    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime);
    }
}
