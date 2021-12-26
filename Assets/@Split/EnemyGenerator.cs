using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject Enemy;

    private float x;
    private float y;
    private float z;

    private int Count;
    private int Max = 3;



    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Generate", 1, 1);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Generate()
    {
        if (Count == Max) return;
        {
            x = Random.Range(-10, 10);
            y = 0;
            z = Random.Range(-10, 10);

            Instantiate(Enemy, new Vector3(x, y, z), Quaternion.identity);

            Count++;
        }
    }
    
}
