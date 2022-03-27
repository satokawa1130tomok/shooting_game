using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using Photon.Pun;
using UnityEngine.UI;

public class player_UI : MonoBehaviour
{
    public Vector3 ScreenOffset = new Vector3(0f, 30f, 0f);
    public Text playerNameText;
    player _target;
    //float _characterControllerHeight;
    Transform _targetTransform;
    Vector3 _targetPosition;

    private void Awake()
    {
        //スライダーをキャンバスの位置にする
        this.GetComponent<Transform>().SetParent(GameObject.Find("Canvas").GetComponent<Transform>());
    }



    void Update()
    {
        //playerがいなくなったら
        if (_target == null)
        {
            //スライダーを削除
            Destroy(this.gameObject);
            return;
        }
    }
    
    private void LateUpdate()
    {
        //playerがいたら
        if (_targetTransform != null)
        {
            //playerのポジションを_targetPositionに入れる
            _targetPosition = _targetTransform.position;
            // プレイヤーの座標をワールド座標からスクリーン座標に変換してスライダーの座標に入れる
            this.transform.position = Camera.main.WorldToScreenPoint(_targetPosition) + ScreenOffset;


        }



    }
    
    public void SetTarget(player.cs taeget)
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
            playerNameText.text = _target.photonView.owner.NickName;
        }
    }
}
