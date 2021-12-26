using Photon.Pun;
using UnityEngine;

public class player : MonoBehaviour
{
    private CharacterController cc;
    private Vector3 Velocity;
    [SerializeField]
    private float JumpPower = 8;//ジャンプ力
    [SerializeField]
    private float MoveSpeed = 10;//移動スピード

    public float sensitivitymax = 200F;//マウスのXの動き
    public float sensitivitynow;//マウスのYの動き

    public float minimumX = 300F;//横の回転の最低値
    public float maximumX = 300f;// //      最高値

    public float minimumY = 300F;//縦の回転の最低値
    public float maximumY = 300f;// //      最高値

    float rotetionX = 0f;//　横軸の回転量
    float rotetionY = 0f;//  横軸

    public GameObject verRot;//縦回転させるオブジェクト（カメラ）
    public GameObject HorRot;//横回転させるオブジェクト（プレイヤー）
    public GameObject muzzle;

    public GameObject bullet;//発射する弾

    [SerializeField]
    private float bulletSpeed = 5000;//玉のスピード

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


    // Start is called before the first frame update
    #endregion

    private CameraWork cameraWork;
    void Start()
    {
        
        HorRot = this.gameObject;
        bullet = GameObject.FindGameObjectWithTag("Bullet");
        verRot = GameObject.FindGameObjectWithTag("MainCamera_");
        ammo_box2 = GameObject.FindGameObjectWithTag("ammo_box");
        this.myPhtonView = GetComponent<PhotonView>();

        cc = GetComponent<CharacterController>();

        cameraWork = GetComponent<CameraWork>();

        if (Canvas_Manager.Spawn_number == 1)
        {
            transform.position = new Vector3(0, 1, 0);
        }
        if (Canvas_Manager.Spawn_number == 2)
        {
            transform.position = new Vector3(122, 1, 3);
        }
        if (Canvas_Manager.Spawn_number == 0)
        {
            #region
            //    = Random.Range(-100, 100);
            //    = 0;
            //    = Random.Range(100, -100)
            #endregion
            transform.position = new Vector3(Random.Range(-200, 200), 100, Random.Range(-100, 100));
        }
        
       #region
        
        //this.myPhotonView = GetComponent<PhotonView>();

        #endregion
    }
    #region
    // Update is called once per frame
    #endregion
    void Update()
    {
        if (cameraWork != null)
        {
            if (this.myPhtonView.IsMine)
            {


                cameraWork.OnStartFollowing();
                Playermove();
                Jump();
                //Rotetion();
                Bullet_();

            }
        }
    }
    #region
    //private void Ontriggerenter(Collider other)
    //{
    //    if (other.gameObject.tag == "ammo_box2")
    //    {
    //        bulletcount++;
    //        Debug.Log(bulletcount);
    //    }
    //}
    //private void OnControllerColliderHit(ControllerColliderHit hit)
    //{
    //    if (hit.gameObject.tag == "ammo_box2")
    //    {
    //        bulletcount++;
    //        Debug.Log(bulletcount);

    //    }


    //}
    #endregion

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ammo_box2")
        {
            bulletcount = +10;

            Destroy(ammo_box2.gameObject);
        }
        #region

        //if (other.gameObject.tag == "potion")
        //{
        //    Destroy(potion.gameObject);
        //}

        #endregion
    }
    void Playermove()
    {
        //Debug.Log("_");
        if (Input.GetKey(KeyCode.W))
        {
            //z方向に進む
           cc.Move(transform.forward * MoveSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            cc.Move(transform.forward * -1f * MoveSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
           cc.Move(transform.right * -1 * MoveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            cc.Move(transform.right * MoveSpeed * Time.deltaTime);
        }
    }
    void Jump()
    {
        if (cc.isGrounded)
        {
            if (Input.GetKey(KeyCode.Space))
                Velocity.y = JumpPower;
        }

    }
    void Bullet_()
    {
        if (bulletcount > 0)
        {
            if (Input.GetKey(KeyCode.E))
            {
                #region
                // GameObject bullets = Instantiate(bullet) as GameObject;
                //bullets.transform.position = this.transform.position;
                //Y = transform.position.y;
                //Instantiate(bullet, new Vector3(transform.position.x, Y, transform.position.z), Quaternion.identity);
                //bullet.transform.position = this.transform.position;
                //force = this.gameObject.transform.forward * bulletSpeed;
                //bullet.GetComponent<Rigidbody>().AddForce(force);
                //Debug.Log(float.IsNaN(Y));
                //Destroy(bullet.gameObject, 4);
                #endregion
                GameObject bullets = Instantiate(bullet) as GameObject;// bulletを作成し、作成したものはbulletsとする
                bullets.transform.position = muzzle.transform.position;// bulletsをプレイヤーの場所に移動させる
                bullet.transform.rotation = muzzle.transform.rotation;
                force = this.gameObject.transform.forward * bulletSpeed;// forceに前方への力を代入する
                bullets.GetComponent<Rigidbody>().AddForce(force);// bulletsにforceの分だけ力をかける
                Destroy(bullets.gameObject, 4);//
                bulletcount--;
            }


        }
    }
    void Rotetion()
    {
        

        rotetionX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * Slidercontroller.now;

        rotetionY += Input.GetAxis("Mouse Y") * Slidercontroller.now;

        verRot.transform.localEulerAngles = new Vector3(-rotetionY, 0, 0);

        x_ = this.transform.position.x;
        y_ = this.transform.position.y;
        z_ = this.transform.position.z;

        verRot.transform.position = new Vector3(x_, y_+5,z_-5) ;

        HorRot.transform.localEulerAngles = new Vector3(0, rotetionX, 0);

        cc.Move(Velocity * Time.deltaTime);

        Velocity.y += Physics.gravity.y * Time.deltaTime;

        //Debug.Log(verRot.transform.position);


    }


    

}





