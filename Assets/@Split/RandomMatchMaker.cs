using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//using 

[System.Diagnostics.DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
public class RandomMatchMaker : MonoBehaviourPunCallbacks
{

    public static bool aaa;
    public float random_X;
    public float random_y;
    public float random_Z;

    Vector3 spawnPosition = new Vector3(0, 1, 0);

    public GameObject avatar;

    public GameObject camera_;

    private GUIStyle style;

    private Vector3 spawn_Position;
    public bool room;
    public GameObject start_button;
    

    // Start is called before the first frame update
    void Start()
    {
        
        //Photonサバに接続
        PhotonNetwork.ConnectUsingSettings();

        style = new GUIStyle();
        style.fontSize = 30;
        room = false;

    }


    // Update is called once per frame
    void OnGUI()
    {
        //ログインの状態を画面上に出力
        //

        GUILayout.Label(PhotonNetwork.NetworkClientState.ToString());

        Rect rect = new Rect(10, 10, 400, 300);
        GUI.Label(rect, PhotonNetwork.NetworkClientState.ToString(), style);

    }


    public override void OnConnectedToMaster()
    {

        PhotonNetwork.NetworkingClient.OpJoinRandomOrCreateRoom(null, null);

    }

    public void Update()
    {
        if(room == true)
        {
            start_button.gameObject.SetActive(true);
        }
        if (room == false)
        {
            start_button.gameObject.SetActive(false);
        }
    }
    //roomに接続した時
    public override void OnJoinedRoom()
    {

        Debug.Log("マスターサーバー" + Button_color.Spawn_number); ;

        if (Button_color.Spawn_number == 1)
        {
            spawn_Position = new Vector3(0, 1, 0);
        }

        if (Button_color.Spawn_number == 2)
        {
            spawn_Position = new Vector3(100, 1, 100);

        }

        if (Button_color.Spawn_number == 0)
        {
            random_X = Random.Range(-100, 100);
            random_y = Random.Range(1, 5);
            random_Z = Random.Range(-100, 100);
            spawn_Position = new Vector3(random_X, random_y, random_Z);

        }

        room = true;

    }

    private string GetDebuggerDisplay()
    {
        return ToString();
    }

    public void Onclick()
    {

       // aaa = true;
        Debug.Log("ルーム" + Button_color.Spawn_number);
        Debug.Log("start");
        SceneManager.LoadScene("PlayScene");


        IEnumerator Timer()
        {
            yield return new WaitForSeconds(10);
        }
        //----------------------------------------------------------------------------------------------------------
        //            ↓クローンを作る　生成する名前　スポーン場所　　　回転していない　　　　　０
        //PhotonNetwork.Instantiate("player", spawn_Position, Quaternion.identity, 0);
        //----------------------------------------------------------------------------------------------------------


        //Debug.Log("spawn"+spawn_Position);
        //Debug.Log("this"+this.transform.position);
        Debug.Log("stop");
    }


}





