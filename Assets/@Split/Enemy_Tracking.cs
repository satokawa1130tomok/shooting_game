using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Enemy_Tracking : MonoBehaviour
{
    public float Enemy_speed = 10.0f;
    public float speed = 1f;
    public Vector3 move_position_;
    public Rigidbody rd;
    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        rd = GetComponent<Rigidbody>();
        target = GameObject.FindWithTag("pl");
    }

    void Update()
    {

        //“®‚­
        Debug.Log("ws" + Enemy_speed);

        //‘O•û‚É‘¬“x‚ğ‚©‚¯‚Ä‚¢‚é
        move_position_ = transform.forward * Enemy_speed;

        //veloctiy‚Émove_position“ü‚ê‚é‚Æi‚Ş
        rd.velocity = move_position_;

        //Œü‚«
        Vector3 vector3 = target.transform.position - this.transform.position;
        Quaternion quaternion = Quaternion.LookRotation(vector3);
        this.transform.rotation = quaternion;


    }
}
