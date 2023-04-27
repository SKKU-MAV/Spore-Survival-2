using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    public Slider hpbar;

    int hp;
    int hpFull;
    [SerializeField] int hpdecrease = 10;

    void Awake()
    {
        hpFull = 100;
    }

    void Update()
    {
         hpbar.value -= hpdecrease; 
       
    }
}
