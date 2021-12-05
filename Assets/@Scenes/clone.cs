using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;


public class clone : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Vector3 spawnPosition = new Vector3(0,10,0);
        PhotonNetwork.Instantiate("player", spawnPosition, Quaternion.identity, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
