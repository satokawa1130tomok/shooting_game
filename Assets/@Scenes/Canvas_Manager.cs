using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Canvas_Manager : MonoBehaviour
{
    public Canvas Map_canvas;
    public Canvas setting_Canvas;
    public Canvas Start_Canvas;
    public static int Spawn_number;



    public void Onclick(int number)
    {
        switch (number)
        {
            case 0:
                Start_Canvas.gameObject.SetActive(false);
                setting_Canvas.gameObject.SetActive(true);
                break;
            case 1:

                Start_Canvas.gameObject.SetActive(true);
                setting_Canvas.gameObject.SetActive(false);
                break;
            case 2:

                Map_canvas.gameObject.SetActive(true);
                setting_Canvas.gameObject.SetActive(false);
                break;
            case 3:

                Map_canvas.gameObject.SetActive(false);
                setting_Canvas.gameObject.SetActive(true);
                break;
            case 4:
                SceneManager.LoadScene("PlayScene");
                break;
            case 5:
                Spawn_number = 1;
                break;
            case 6:
                Spawn_number = 2;
                break;




        }
    }
}
