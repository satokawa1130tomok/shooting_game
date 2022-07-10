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

    // Start is called before the first frame update
    void Start()
    {
        rd = GetComponent<Rigidbody>();
        this.myPhtonView = GetComponent<PhotonView>();
        target = GameObject.FindWithTag("pl");
    }

    void Update()
    {

        if (this.myPhtonView.IsMine)
        {
            move();
        }
        



    }

  
  public void move()
    {
        //ìÆÇ≠
        Debug.Log("ws" + Enemy_speed);

        //ëOï˚Ç…ë¨ìxÇÇ©ÇØÇƒÇ¢ÇÈ
        move_position_ = transform.forward* Enemy_speed;

        //veloctiyÇ…move_positionì¸ÇÍÇÈÇ∆êiÇﬁ
       rd.velocity = move_position_;

        //å¸Ç´
        Vector3 vector3 = target.transform.position - this.transform.position;
        Quaternion quaternion = Quaternion.LookRotation(vector3);
        this.transform.rotation = quaternion;
    }

}
