using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;


public class Enemy_Tracking : MonoBehaviourPunCallbacks
{
    public float Enemy_speed = 10.0f;
    public float speed = 1f;
    public Vector3 move_position_;
    public Rigidbody rd;
    public GameObject target;
    PhotonView myPhtonView;
    public float distance;
    

    // Start is called before the first frame update
    void Start()
    {
        rd = GetComponent<Rigidbody>();
        this.myPhtonView = GetComponent<PhotonView>();
        

    }

    void Update()
    {
       Vector3 posA = target.transform.position;
       Vector3 posB = this.transform.position;
       distance = Vector3.Distance(posA, posB);
        Debug.Log(posA + "_" + posB + "_" +  distance);
        

        if (this.myPhtonView.IsMine)
        {
            
            if(distance < 61)
            {
               move();
            }
            
        } 
        
        if(target == null)
        {
            target = GameObject.Find("player(Clone)");

        }



    }

  
  public void move()
    {
        //動く
        Debug.Log("ws" + Enemy_speed);

        //前方に速度をかけている
        move_position_ = transform.forward* Enemy_speed;

        //veloctiyにmove_position入れると進む
       rd.velocity = move_position_;

        //向き
        Vector3 vector3 = target.transform.position - this.transform.position;
        Quaternion quaternion = Quaternion.LookRotation(vector3);
        this.transform.rotation = quaternion;
    }

}
