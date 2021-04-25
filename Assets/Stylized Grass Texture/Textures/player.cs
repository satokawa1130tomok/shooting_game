using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    private CharacterController characterController;
    private Vector3 Velocity;
    [SerializeField]
    private float JumpPower = 8;//ジャンプ力
    [SerializeField]
    private float MoveSpeed = 10;//移動スピード

    public float sensitivityX = 15F;//マウスのXの動き
    public float sensitivityY = 15F;//マウスのYの動き

    public float minimumX = 360F;//横の回転の最低値
    public float maximumX = 360f;// //      最高値

    public float minimumY = 360F;//縦の回転の最低値
    public float maximumY = 360f;// //      最高値

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

    // Start is called before the first frame update
    void Start()
    {

        characterController = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        rotetionX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;

        rotetionY += Input.GetAxis("Mouse Y") * sensitivityY;

        verRot.transform.localEulerAngles = new Vector3(-rotetionY, 0, 0);

        HorRot.transform.localEulerAngles = new Vector3(0, rotetionX, 0);

        if (Input.GetKey(KeyCode.W))
        {
            characterController.Move(this.gameObject.transform.forward * MoveSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            characterController.Move(this.gameObject.transform.forward * -1f * MoveSpeed * Time.deltaTime);

        }

        if (Input.GetKey(KeyCode.A))
        {
            characterController.Move(this.gameObject.transform.right * -1 * MoveSpeed * Time.deltaTime);

        }
        if (Input.GetKey(KeyCode.D))
        {
            characterController.Move(this.gameObject.transform.right * MoveSpeed * Time.deltaTime);

        }
        if (bulletcount > 0)
        {
            if (Input.GetKey(KeyCode.E))
            {
                // GameObject bullets = Instantiate(bullet) as GameObject;
                //bullets.transform.position = this.transform.position;
                //Y = transform.position.y;
                //Instantiate(bullet, new Vector3(transform.position.x, Y, transform.position.z), Quaternion.identity);
                //bullet.transform.position = this.transform.position;
                //force = this.gameObject.transform.forward * bulletSpeed;
                //bullet.GetComponent<Rigidbody>().AddForce(force);
                //Debug.Log(float.IsNaN(Y));
                //Destroy(bullet.gameObject, 4);
                GameObject bullets = Instantiate(bullet) as GameObject;// bulletを作成し、作成したものはbulletsとする
                bullets.transform.position = muzzle.transform.position;// bulletsをプレイヤーの場所に移動させる
                bullet.transform.rotation = muzzle.transform.rotation;
                force = this.gameObject.transform.forward * bulletSpeed;// forceに前方への力を代入する
                bullets.GetComponent<Rigidbody>().AddForce(force);// bulletsにforceの分だけ力をかける
                Destroy(bullets.gameObject, 4);//
                bulletcount--;

            }
        }
        characterController.Move(Velocity * Time.deltaTime);

        Velocity.y += Physics.gravity.y * Time.deltaTime;

        if (characterController.isGrounded)
        {
            if (Input.GetKey(KeyCode.Space))
                Velocity.y = JumpPower;
        }



    }
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
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ammo_box2")
        {
           
            bulletcount　=+10;
            Debug.Log("hit");
            Destroy(ammo_box2.gameObject);
        }
        //if (other.gameObject.tag == "potion")
        //{
        //    Destroy(potion.gameObject);
        //}
    }
    
}
    
    
     


