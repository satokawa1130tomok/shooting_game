using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;
//using 

[System.Diagnostics.DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
public class RandomMatchMaker : MonoBehaviourPunCallbacks
{

    Vector3 spawnPosition = new Vector3(0, 10, 0);

    public GameObject avatar;

    public GameObject camera_;

    private GUIStyle style;

    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        style = new GUIStyle();
        style.fontSize = 30;
    }

    // Update is called once per frame
    void OnGUI()
    {
        //ログインの状態を画面上に出力
        //

        GUILayout.Label(PhotonNetwork.NetworkClientState.ToString());

        Rect rect = new Rect(10, 10, 400, 300);
        GUI.Label(rect, (PhotonNetwork.NetworkClientState.ToString()), style);

    }

    public override void OnJoinedLobby()
    {
        Debug.Log("ルームに接続中…");
        PhotonNetwork.JoinRandomRoom();
    }
    //マスターサーバーに接続したら
    public override void OnConnectedToMaster()
    {

        Debug.Log("ルーム作成中…");
        // "room"という名前のルームに参加する（ルームが無ければ作成してから参加する）
        PhotonNetwork.JoinOrCreateRoom("room", new RoomOptions(), TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.IsMessageQueueRunning = false;
        // シーンをバックグラウンドで非同期にロード SceneManager.LoadSceneAsync("PlayScene", LoadSceneMode.Single);
        Debug.Log("Joined");
        //キャラクターを生成
        //GameObject monster = PhotonNetwork.Instantiate("Tank", Vector3.zero, Quaternion.identity, 0);

        //SceneManager.LoadScene("PlayScene");

        SceneManager.LoadScene("test");

        GameObject avater = PhotonNetwork.Instantiate("player_", spawnPosition, Quaternion.identity, 0);
        camera_.transform.parent = avatar.transform;
        camera_.transform.position = avatar.transform.position;
    }

    private string GetDebuggerDisplay()
    {
        return ToString();
    }
}





