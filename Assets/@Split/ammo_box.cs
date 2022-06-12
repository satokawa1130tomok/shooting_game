using System.Collections.Generic;
using UnityEngine;

public class ammo_box : MonoBehaviour
{

    public GameObject ammobox;
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

        Instantiate(ammobox, new Vector3(x, y, z), Quaternion.identity);

    }
}
