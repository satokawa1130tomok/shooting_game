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

        //����
        Debug.Log("ws" + Enemy_speed);

        //�O���ɑ��x�������Ă���
        move_position_ = transform.forward * Enemy_speed;

        //veloctiy��move_position�����Ɛi��
        rd.velocity = move_position_;

        //����
        Vector3 vector3 = target.transform.position - this.transform.position;
        Quaternion quaternion = Quaternion.LookRotation(vector3);
        this.transform.rotation = quaternion;


    }
}
