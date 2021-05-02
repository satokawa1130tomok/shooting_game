using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slidercontroller : MonoBehaviour
{
    public Slider mauseslider;
    public float max=200;
    public static float now;

    // Start is called before the first frame update
    void Start()
    {
        mauseslider = GetComponent<Slider>();
        mauseslider.maxValue = max;
        Debug.Log(max);
            

    }

    // Update is called once per frame
    void Update()
    {
        now　= mauseslider.maxValue;
    }
}



































