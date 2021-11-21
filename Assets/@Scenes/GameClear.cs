using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameClear : MonoBehaviour
{

    public GameObject[] enemyObjects;
    public GameObject　ClearText ;

    // Start is called before the first frame update
    void Start()
    {
        this.ClearText = GameObject.FindWithTag("text");
        ClearText.GetComponent<Text>().enabled = false;
        enemyObjects = GameObject.FindGameObjectsWithTag("Tank (1)");

    }

    // Update is called once per frame
    void Update()
    {

        //if (enemyObjects.Length == 0)

        //{
            //ClearText.GetComponent<Text>().enabled=true;
        //}
    }
}
