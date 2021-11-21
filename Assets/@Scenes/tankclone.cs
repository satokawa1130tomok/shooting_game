using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tankclone: MonoBehaviour
{

    public GameObject originObject;

    // Use this for initialization
    void Start()
    {
        Instantiate(originObject, new Vector3(-155, -93, -77), Quaternion.identity);
            // Instantiate(originObject, new Vector3(-1.0f, 0.0f, 0.0f), Quaternion.identity);
    }

}
