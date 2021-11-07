﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class RandomMatchMaker : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    // Update is called once per frame
    void OnGUI()
    {
        //ログインの状態を画面上に出力
        GUILayout.Label(PhotonNetwork.NetworkClientState.ToString());
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("ルームに接続中…");
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("ルーム作成中…");
        // "room"という名前のルームに参加する（ルームが無ければ作成してから参加する）
        PhotonNetwork.JoinOrCreateRoom("room", new RoomOptions(), TypedLobby.Default);
    }

        public override void OnJoinedRoom()
    {
        Debug.Log("Joined");
        //キャラクターを生成
        GameObject monster = PhotonNetwork.Instantiate("Tank", Vector3.zero, Quaternion.identity, 0);


    }
}
