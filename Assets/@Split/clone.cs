using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;


 
public class clone : MonoBehaviour
{
    public GameObject avatar;

    public GameObject camera_;

// Start is called before the first frame update
void Start()
    {
        Vector3 spawnPosition = new Vector3(0,10,0);

        //

        //GameObject avater = PhotonNetwork.Instantiate("player_", spawnPosition, Quaternion.identity, 0);
        //camera_.transform.parent = avatar.transform;
        //camera_.transform.position = avatar.transform.position;
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
