﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class clone_manager : MonoBehaviour
{

    public Vector3 clone_position;
    public float XXX;
    public float YYY;
    public float ZZZ;
       

    // Update is called once per frame
    void　Start　()
    {
        if(Canvas_Manager.Spawn_number == 1)
        {
            clone_position = new Vector3(0, 1, 0);
        }
        if(Canvas_Manager.Spawn_number==2)
        {
            clone_position = new Vector3(100, 1, 100);
        }
        if(Canvas_Manager.Spawn_number==0)
        {
            XXX = Random.Range(100, -100);
            YYY = Random.Range(1, 100);
            ZZZ = Random.Range(100, -100);
            clone_position = new Vector3(XXX, YYY, ZZZ);
        }
        Debug.Log("nb" + Canvas_Manager.Spawn_number);
        Debug.Log("cp" + clone_position);


        PhotonNetwork.Instantiate("player", clone_position, Quaternion.identity, 0);
        
   
    }
}