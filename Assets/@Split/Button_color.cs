using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class Button_color : MonoBehaviour
{
    public static int Spawn_number;
    public GameObject Button1;
    public GameObject Button2;
    public GameObject Button3;
    public GameObject random_text;

    // Start is called before the first frame update
    void Start()
    {
        Spawn_number = 1;
        Button1.GetComponent<Image>().color = Color.white;
        Button2.GetComponent<Image>().color = Color.white;
        Button3.GetComponent<Image>().color = Color.white;
       
    }

    public void Onclick(int number)
    {
        switch (number)
        {
            case 0:


                Spawn_number = 1;
                Button1.GetComponent<Image>().color = Color.gray;
                Button2.GetComponent<Image>().color = Color.white;
                Button3.GetComponent<Image>().color = Color.white;
                
                break;
            case 1:
                Spawn_number = 2;
                Button1.GetComponent<Image>().color = Color.white;
                Button2.GetComponent<Image>().color = Color.gray;
                Button3.GetComponent<Image>().color = Color.white;
                
                break;
            case 2:
                Spawn_number = 0;
                Button1.GetComponent<Image>().color = Color.white;
                Button2.GetComponent<Image>().color = Color.white;
                Button3.GetComponent<Image>().color = Color.gray;
              
                break;
        }
    }
}