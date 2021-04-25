using UnityEngine;

public class Destroy : MonoBehaviour
{
    public GameObject player;
    void Start()
    {
        this.gameObject.SetActive(true);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("当たった");
            this.gameObject.SetActive(false);

        }
        Destroy(this.gameObject);


        //    }
        //}
        //private void OnCollisionEnter(Collision collision)
        //{
        //if (collision.gameObject.tag == "Player")
        //{
        //    Debug.Log("当たった");
        //    //this.gameObject.SetActive(false)
        //    Destroy(this.gameObject);

        //}
        //}

    }
}