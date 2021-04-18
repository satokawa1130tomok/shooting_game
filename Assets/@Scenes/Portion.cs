using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portion : MonoBehaviour
{
    public GameObject Potion_clone;
    private float x;
    private float y;
    private float z;
    float ammoboxtime;



    // Start is called before the first frame update
    void Start()
    {
        Generate();
        InvokeRepeating("Gemerate", 1, 1);
    }

    private void Update()
    {
        ammoboxtime += Time.deltaTime;
        if (ammoboxtime > 30)
        {
            Generate();
            ammoboxtime = 0f;

        }

    }
    void Generate()
    {
        x = Random.Range(-100, 100);
        y = 0;
        z = Random.Range(100, -100);

        Instantiate(Potion_clone, new Vector3(x, y, z), Quaternion.identity);

    }
    
}

