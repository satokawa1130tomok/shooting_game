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
    public GameObject[] target;
    PhotonView myPhtonView;
    public float distance;
    private GameObject confirm_target;
    private bool HP = false;
    //private GameObject Bullet;
    // Start is called before the first frame update
    void Start()
    {
        rd = GetComponent<Rigidbody>();
        this.myPhtonView = GetComponent<PhotonView>();


    }

    void Update()
    {
        if(HP == true)
        {
            player.Destroy_count++;
            Destroy(this.gameObject);
            Debug.Log("/" + HP);
        }
        target = GameObject.FindGameObjectsWithTag("pl");
        confirm_target = target[0];

        for (int i = 0; i < target.Length; i++)
        {
      
            Vector3 posA = target[i].transform.position;
            Vector3 posB = this.transform.position;
            distance = Vector3.Distance(posA, posB);

            if (Vector3.Distance(confirm_target.transform.position,this.transform.position) > distance)
            {
                confirm_target = target[i];
            }

            
        }
           Vector3 vector3 = confirm_target.transform.position - this.transform.position;
           Quaternion quaternion = Quaternion.LookRotation(vector3);
           this.transform.rotation = quaternion;
           // Debug.Log(posA + "_" + posB + "_" +  distance);


        if (this.myPhtonView.IsMine)
        {

            if (distance < 61)
            {
                move();
            }

        }

        if (target == null)
        {


        }



    }


    public void move()
    {
        //“®‚­
        //Debug.Log("ws" + Enemy_speed);

        //‘O•û‚É‘¬“x‚ð‚©‚¯‚Ä‚¢‚é
        move_position_ = transform.forward * Enemy_speed;

        //veloctiy‚Émove_position“ü‚ê‚é‚Æi‚Þ
        rd.velocity = move_position_;

        //Œü‚«


    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("aaaa/" + HP);
        if (collision.gameObject.tag == "Bullet")
        {
            HP = true;
            Debug.Log("aaa" + HP);
        }
    }


}
