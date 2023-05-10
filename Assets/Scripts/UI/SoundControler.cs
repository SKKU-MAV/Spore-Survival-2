using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundControler : MonoBehaviour
{
    public Slider soundBar;

    // Update is called once per frame
    void Update()
    {
        AudioListener.volume = soundBar.value;
    }
}
