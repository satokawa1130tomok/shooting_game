using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class player_UI : MonoBehaviour
{
    public Vector3 ScreenOffset = new Vector3(0f, 60f, 0f);
    public Text playerNameText;
   //float _characterControllerHeight;
    Transform _targetTransform;
    Vector3 _targetPosition;
    PlayerManager _target;

    private void Awake()
    {
        //スライダーをキャンバスの位置にする
        this.GetComponent<Transform>().SetParent(GameObject.Find("Canvas").GetComponent<Transform>());
    }



    void Update()
    {
        Debug.Log("aa");
        //playerがいなくなったら
        if (_target == null)
        {
            //スライダーを削除
            //Destroy(this.gameObject);
            return;


        }

        //playerがいたら
        if (_targetTransform != null)
        {
            //playerのポジションを_targetPositionに入れる
            _targetPosition = _targetTransform.position;
            // プレイヤーの座標をワールド座標からスクリーン座標に変換してスライダーの座標に入れる
            this.transform.position = Camera.main.WorldToScreenPoint(_targetPosition) + ScreenOffset;
            Debug.Log("a");
            
            
        }
        Debug.Log("aaa");
        
    }
    
    //private void LateUpdate()
    //{
       

    //    Debug.Log("pu");

    //}
    
    public void SetTarget(PlayerManager taeget)
    {

        if (taeget == null)
        {
            Debug.LogError("<Color=Red><a>Missing</a></Color> PlayMakerManager target for PlayerUI.SetTarget.", this);
            return;
        }
        
        _target = taeget;
        _targetTransform = _target.GetComponent<Transform>();
        //CharacterController _characterController = _target.GetComponent<CharacterController>();


        if (playerNameText != null)
        {
            playerNameText.text = _target.photonView.Owner.NickName;
        }
    }
}
