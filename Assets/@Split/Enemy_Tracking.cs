using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Enemy_Tracking : MonoBehaviour
{
     public float ws;
    public float ad;
    public float speed = 10f;
    public Vector3 move_position_;
    public Rigidbody rd;
    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        rd = GetComponent<Rigidbody>();
        target = GameObject.FindWithTag("pl");
    }

    // Update is called once per frame
    void Update()
    {

        //“®‚­
        move_position_ = new Vector3(ad, 0, 0);
        Debug.Log("ws" + ws + "ad" + ad);


        move_position_ = transform.forward * ws;

        rd.velocity = move_position_;
        //Œü‚«

        Vector3 vector3 = target.transform.position - this.transform.position;
        Quaternion quaternion = Quaternion.LookRotation(vector3);
        this.transform.rotation = quaternion;
        

    }
}
