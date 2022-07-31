using System.Collections.Generic;
using UnityEngine;

public class ammo_box : MonoBehaviour
{

    public GameObject ammobox;
    private int random;
    private float x;
    private float y;
    private float z;
    private float ammoboxtime;
    private int ammobox_count;



    // Start is called before the first frame update
    void Start()
    {
        Random_();
        Generate();
        InvokeRepeating("Gemerate", 1, 1);
        ammobox_count = 0;
        
    }

    private void Update()
    {
        ammoboxtime += Time.deltaTime;
        if (ammoboxtime > 30)
        {
            
            
              Generate();
              ammoboxtime = 0f;

            
           

        }
       if (Input.GetKey(KeyCode.Q)) { Generate(); }

    }


    void Generate()
    {


        if (ammobox_count < 6)
        {
            Instantiate(ammobox, new Vector3(x, y, z), Quaternion.identity);
            ammobox_count++;
            Random_();


        }
            


    }
    void Random_()
    {
        random = Random.Range(1, 11);
        if (random == 1) { x = 35; y = 0; z = -11; }
        if (random == 2) { x = 77; y = 0; z = 31; }
        if (random == 3) { x = 80; y = 0; z = 92; }
        if (random == 4) { x = 8; y = 0; z = 47; }
        if (random == 5) { x = 60; y = 0; z = 120; }
        if (random == 6) { x = 7; y = 0; z = 74; }
        if (random == 7) { x = -29; y = 0; z = 46; }
        if (random == 8) { x = -66; y = 22; z = -16; }
        if (random == 9) { x = -80; y = 22; z = -11; }
        if (random == 10) { x = -100; y = 54; z = 54; }
         
      

    }
    
    
}
