using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class Canvas_Manager : MonoBehaviourPunCallbacks

{
    public Canvas Map_canvas;
    public Canvas setting_Canvas;
    public Canvas Start_Canvas;
    public Canvas Name_Canvas;
    public GameObject st_button;



    private void Start()
    {
 
        Start_Canvas.gameObject.SetActive(true);
        setting_Canvas.gameObject.SetActive(false);
        Map_canvas.gameObject.SetActive(false);
        Name_Canvas.gameObject.SetActive(false);
        
    }
    public void Onclick(int number)
    {
        switch (number)
        {
            case 1:
                Start_Canvas.gameObject.SetActive(false);
                Name_Canvas.gameObject.SetActive(true);
              
                break;
            case 2:
                Name_Canvas.gameObject.SetActive(false);
                Map_canvas.gameObject.SetActive(true);
                break;
            case 3:
                Map_canvas.gameObject.SetActive(false);
                Name_Canvas.gameObject.SetActive(true);
                break;
            case 4:
                Name_Canvas.gameObject.SetActive(false);
                setting_Canvas.gameObject.SetActive(true);
               break;
            case 5:
                setting_Canvas.gameObject.SetActive(false);
                Name_Canvas.gameObject.SetActive(true);
                break;



                
                   
           



               
        }
    }


   

}
