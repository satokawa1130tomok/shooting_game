using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class random : MonoBehaviour
{
    public GameObject Bullet2_animations;

    private float X;
    private float y;
    private float z;

    private int Count;
    private int Max = 100;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Generate", 1, 1);
    }

    // Update is called once per frame
    void Generste()
    {
        //Debug.Log("a");
        if (Count < Max) //return;
        {
            X = Random.Range(-5, 5);
            y = 0;
            z = Random.Range(-5, 5);
            Instantiate(Bullet2_animations, new Vector3(X, y, z),Quaternion.identity);
            Count++;
            //Debug.Log("b");
        }
                
    }
}
