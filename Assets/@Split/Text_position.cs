using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Text_position : MonoBehaviour
{

    public Text TextFrame_X;
    public Text TextFrame_Y;
    public Text TextFrame_Z;
    public GameObject player_;

    // Start is called before the first frame update
    void Start()
    {
        //if ( player_ == null)
        //{
        //    SceneManager.LoadScene("StartScene");
        //}
     
    }

    // Update is called once per frame
    void Update()
    {
        if(player_ == null)
        {
            player_ = GameObject.FindGameObjectWithTag("pl");
        }
      

        float X = player_.transform.position.x;
        TextFrame_X.text = X.ToString("f0");


        float Y = player_.transform.position.y;
        TextFrame_Y.text = Y.ToString("f0");

        float Z = player_.transform.position.z;
        TextFrame_Z.text = Z.ToString("f0");

    }
}
