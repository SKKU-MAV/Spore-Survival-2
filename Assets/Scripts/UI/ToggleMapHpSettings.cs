using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleMapHpSettings : MonoBehaviour
{
    public Behaviour map;
    public Behaviour hp;
    public Behaviour bp;
    public Behaviour settings;

    private void Awake()
    {
        map.enabled = false;
        hp.enabled = false;
        bp.enabled = false;
        settings.enabled = false;
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            if (settings.enabled) settings.enabled = false;
            else settings.enabled = true;
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (map.enabled) map.enabled = false;
            else map.enabled = true;
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            if (hp.enabled && bp.enabled)
            {
                hp.enabled = false;
                bp.enabled = false;
            }
            else
            {
                hp.enabled = true;
                bp.enabled = true;
            }
        }
    }
}
