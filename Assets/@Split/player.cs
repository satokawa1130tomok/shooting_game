using Photon.Pun;
using UnityEngine;
using Photon.Realtime;

public class player : MonoBehaviourPunCallbacks
{
    float rotationX = 0f;
    float rotationY = 0f;

    public float sensitivityX = 15F;
    public float sensitivityY = 15F;



    private float JumpPower = 8;//ジャンプ力


    public float sensitivitymax = 200F;//マウスのXの動き
    public float sensitivitynow;//マウスのYの動き

    public float minimumX = 300F;//横の回転の最低値
    public float maximumX = 300f;// //      最高値

    public float minimumY = 300F;//縦の回転の最低値
    public float maximumY = 300f;// //      最高値

    float rotetionX = 0f;//　横軸の回転量
    float rotetionY = 0f;//  横軸

    public GameObject verRot_;//縦回転させるオブジェクト（カメラ）
    public GameObject HorRot;//横回転させるオブジェクト（プレイヤー）
    public Transform muzzle;

    public GameObject bullet;//発射する弾

    [SerializeField]
    public float bulletSpeed = 5000;//玉のスピード

    private Vector3 force;//弾を飛ばす力
    private float Y;

    public int bulletcount;
    public GameObject ammo_box2;
    public GameObject potion;
    public Vector3 position;
    PhotonView myPhtonView;
    #region

    public float x_;
    public float y_;
    public float z_;
    public Rigidbody rd;


    public float speed = 15.0f;


    public float rotationSpeed = 10.0f;

    public float ws;
    public float ad;

    public Vector3 move_position_;

    public Vector3 zyx;

    //Renderer targetRenderer;

    #endregion



    private CameraWork cameraWork;
    void Start()
    {

        this.tag = "pl";
        /////////////
        //targetRenderer = GetComponent<Renderer>();

        //PhotonNetwork.Instantiate("player_UI", this.transform.position, Quaternion.identity,0);


        verRot_ = transform.GetChild(0).gameObject;
        rd = GetComponent<Rigidbody>();


        HorRot = this.gameObject;
        //bullet = GameObject.FindGameObjectWithTag("Bullet");
        //0番目のgameobjectをverrotに入れる
        muzzle = this.gameObject.transform.GetChild(1);


        ammo_box2 = GameObject.FindGameObjectWithTag("ammo_box");

        this.myPhtonView = GetComponent<PhotonView>();
        //verRot_.SetActive(false);

        if (!myPhtonView.IsMine)
        {
            verRot_.SetActive(false);
        }



        //if (Canvas_Manager.Spawn_number == 1)
        //{
        //    transform.position = new Vector3(0, 1, 0);
        //}
        //if (Canvas_Manager.Spawn_number == 2)
        //{
        //    transform.position = new Vector3(122, 1, 3);
        //}



    }



    void Update()
    {

        if (this.myPhtonView.IsMine)
        {
            verRot_.SetActive(true);
            //===============================//
            //cameraWork.OnStartFollowing(); //
            Playermove();                    //
            //Jump();                        //
            Rotetion(); 　　　　　　　　　　　　 //
            Bullet_();                       //
            //===============================//
        }



    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ammo_box2")
        {
            bulletcount = +10;

            Destroy(ammo_box2.gameObject);
        }
        #region


        #endregion
    }
    void Playermove()
    {
        //========================================//
        //Vertical:縦                             //
        //Horizontal:横                           //
        //=======================================//
        ws = Input.GetAxis("Vertical") * speed;
        ad = Input.GetAxis("Horizontal") * speed;

        move_position_ = new Vector3(ad, 0, 0);
      //  Debug.Log("ws" + ws + "ad" + ad);

        if (ws != 0)
        {
            move_position_ = transform.forward * ws;

            rd.velocity = move_position_;

        }

        if (ad != 0)
        {
            move_position_ = transform.right * ad;

            rd.velocity = move_position_;

        }
    }
    void Jump()
    {

    }
    void Bullet_()
    {

        if (Input.GetKey(KeyCode.E) && bulletcount > 0)
        {

            photonView.RPC("Shot", RpcTarget.All, muzzle.transform.position);

        } 

    }

    [PunRPC]
    private void Shot(Vector3 position)
    {

        GameObject bullets = Instantiate(bullet) as GameObject;// bulletを作成し、作成したものはbulletsとする

        bullets.transform.position = position;// bulletsをプレイヤーの場所に移動させる

        bullet.transform.rotation = muzzle.transform.rotation;

        force = this.gameObject.transform.forward * bulletSpeed;// forceに前方への力を代入する

        bullets.GetComponent<Rigidbody>().AddForce(force);// bulletsにforceの分だけ力をかける

        Destroy(bullets.gameObject, 4);
        bulletcount--;

    }

    void Rotetion()
    {




        //============================================================
        //rotetionx　=　X方向の回転
        //transform.localEulerAngles.y = y軸の回転
        //Input.GetAxis("Mouse X")　= マウスの横の移動量
        //X方向の回転 = y軸の回転 + マウスの横の移動量 * 15
        rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;

        //Y方向の回転　＋＝　マウスの移動量　*  15
        rotationY += Input.GetAxis("Mouse Y") * sensitivityY;

        //
        rotationY = Mathf.Clamp(rotationY, 100000, 1000000);

        verRot_.transform.localEulerAngles = new Vector3(-rotationY, 0, 0);
        HorRot.transform.localEulerAngles = new Vector3(0, rotationX, 0);
        //============================================================


    }




}