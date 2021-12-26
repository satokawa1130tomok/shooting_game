using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawnbutton : MonoBehaviour
{
    public static int Button_number;
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(Click);
    }
    void Click ()
    {
        Button_number = 1;
    }
}
