using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class Canvas_Manager : MonoBehaviour
{
    public Canvas Map_canvas;
    public Canvas setting_Canvas;
    public Canvas Start_Canvas;
    public static int Spawn_number;
    public GameObject  Button1;
    public GameObject Button2;
    public GameObject Button3;



    private void Start()
    {
        Spawn_number = 1;
        Button1.GetComponent<Image>().color = Color.white;
        Button2.GetComponent<Image>().color = Color.white;
        Button3.GetComponent<Image>().color = Color.white;
        Start_Canvas.gameObject.SetActive(true);
        setting_Canvas.gameObject.SetActive(false);
        Map_canvas.gameObject.SetActive(false);
    }
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
                Debug.Log("ルーム作成中…");
                // "room"という名前のルームに参加する（ルームが無ければ作成してから参加する）
                PhotonNetwork.JoinOrCreateRoom("room", new RoomOptions(), TypedLobby.Default);
                SceneManager.LoadScene("PlayScene");
                break;
            case 5:
                Spawn_number=1;
                Button1.GetComponent<Image>().color = Color.blue;
                Button2.GetComponent<Image>().color = Color.white;
                Button3.GetComponent<Image>().color = Color.white;
                break;
            case 6:
                Spawn_number = 2;
                Button1.GetComponent<Image>().color = Color.white;
                Button2.GetComponent<Image>().color = Color.blue;
                Button3.GetComponent<Image>().color = Color.white;
                break;
            case 7:
                Spawn_number = 0;
                Button1.GetComponent<Image>().color = Color.white;
                Button2.GetComponent<Image>().color = Color.white;
                Button3.GetComponent<Image>().color = Color.blue;
                break;



               
        }
    }
}
