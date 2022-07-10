using System.Collections;
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
    public int Enemy_count = 1;


    // Update is called once per frame
    void　Start　()
    {
        if(Button_color.Spawn_number == 1)
        {
            clone_position = new Vector3(0, 2, 0);
        }
        if(Button_color.Spawn_number==2)
        {
            clone_position = new Vector3(100, 2, 100);
        }
        if(Button_color.Spawn_number==0)
        {
            XXX = Random.Range(100, -100);
            YYY = Random.Range(1, 100);
            ZZZ = Random.Range(100, -100);
            clone_position = new Vector3(XXX, YYY, ZZZ);
        }
        Debug.Log("nb" + Button_color.Spawn_number);
        Debug.Log("cp" + clone_position);


        PhotonNetwork.Instantiate("player", clone_position, Quaternion.identity, 0);

        PhotonNetwork.Instantiate("Tank (1)", clone_position, Quaternion.identity, 0);
        PhotonNetwork.Instantiate("Tank (1)", clone_position, Quaternion.identity, 0);
        PhotonNetwork.Instantiate("Tank (1)", clone_position, Quaternion.identity, 0);



    }

    
}
