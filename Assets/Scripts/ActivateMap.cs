using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateMap : MonoBehaviour
{
    public Behaviour target;

    private void Awake()
    {
        target.enabled = false;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            if (target.enabled) target.enabled = false;
            else target.enabled = true;
        }
    }
}
