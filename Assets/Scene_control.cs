using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_control : MonoBehaviour
{
    public static bool  Scenecontrol;
    // Start is called before the first frame update
    void Start()
    {
        Scenecontrol = false;
        Invoke("A_", 0.2f);
    }
    public void A_()
    {
        if(Scenecontrol == false)
        {
            SceneManager.LoadScene("Start screen");
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
