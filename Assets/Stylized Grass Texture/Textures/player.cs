using Photon.Pun;
using UnityEngine;

public class player : MonoBehaviour
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
    public Rigidbody rd;


    public float speed = 10.0f;


    public float rotationSpeed = 10.0f;

    public float ws;
    public float ad;

    public Vector3 move_position_;

    public Vector3 zyx;
    
    #endregion

    private CameraWork cameraWork;
    void Start()
    {
        rd = GetComponent<Rigidbody>();


        HorRot = this.gameObject;
        bullet = GameObject.FindGameObjectWithTag("Bullet");
        //GameObject child = transform.GetChild(0).gameObject;
        ammo_box2 = GameObject.FindGameObjectWithTag("ammo_box");
        verRot_ = GameObject.FindGameObjectWithTag("MainCamera_");
        this.myPhtonView = GetComponent<PhotonView>();

      

        cameraWork = GetComponent<CameraWork>();

        if (Canvas_Manager.Spawn_number == 1)
        {
            transform.position = new Vector3(0, 1, 0);
        }
        if (Canvas_Manager.Spawn_number == 2)
        {
            transform.position = new Vector3(122, 1, 3);
        }



       
    }
   
    void Update()
    {


        if (this.myPhtonView.IsMine)
        {

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
      
        move_position_ = new Vector3(ws, 0, ad);

        ad = ad - ad - ad;
        rd.velocity = move_position_;


    }
    void Jump()
    {
       
    }
    void Bullet_()
    {
        if (bulletcount > 0)
        {
            if (Input.GetKey(KeyCode.E))
            {
                

                GameObject bullets = Instantiate(bullet) as GameObject;// bulletを作成し、作成したものはbulletsとする

                bullets.transform.position = muzzle.transform.position;// bulletsをプレイヤーの場所に移動させる
                
                bullet.transform.rotation = muzzle.transform.rotation;

                force = this.gameObject.transform.forward * bulletSpeed;// forceに前方への力を代入する

                bullets.GetComponent<Rigidbody>().AddForce(force);// bulletsにforceの分だけ力をかける

                Destroy(bullets.gameObject, 4);
                bulletcount--;
            }


        }
    }
    void Rotetion()
    {

        rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;

        rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
        rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);
        
        verRot_.transform.localEulerAngles = new Vector3(-rotationY, 0, 0);
        HorRot.transform.localEulerAngles = new Vector3(0, rotationX, 0);



    }




}





