using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slidercontroller : MonoBehaviour
{
    private Slider mauseslider;
    public float max=200;
    public static float now=50;
    void Start()
    {
        mauseslider = GetComponent<Slider>();
        mauseslider.maxValue = max;
        Debug.Log(max);
        mauseslider.value = now;
 
    }

    void Update()
    {
       
    }
    public void Slidervalue()
    {
        now = mauseslider.value;
        Debug.Log(now);
    }

}