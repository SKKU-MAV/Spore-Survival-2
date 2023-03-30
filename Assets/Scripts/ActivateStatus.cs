using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateStatus : MonoBehaviour
{
    public Behaviour target;
  

    private void Awake()
    {
        target.enabled = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            if (target.enabled) target.enabled = false;
            else target.enabled = true;
        }
    }
}
