using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceTarget : MonoBehaviour
{
    GameObject targetObject;
    Transform target;
    [SerializeField]
    float turnSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        targetObject = GameObject.Find("XR Origin");
        target = targetObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Face();
    }

    private void Face()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }
}
