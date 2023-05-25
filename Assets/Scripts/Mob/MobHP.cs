using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MobHP : MonoBehaviour
{
    public Slider hpbar;
    [SerializeField]
    GameObject obj;
    float hp = 100;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        hp = obj.GetComponent<MobHit>().getHP();
        hpbar.value = hp;
    }
}
