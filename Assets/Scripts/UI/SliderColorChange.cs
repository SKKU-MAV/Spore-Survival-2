using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderColorChange : MonoBehaviour
{
    public Slider hpbar;
    public Image slider1Fill;

    public void Update()
    {
        slider1Fill.color = Color.Lerp(Color.blue,Color.red, hpbar.value / 100);
    }
}
