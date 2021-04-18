using UnityEngine;

public class Destroy : MonoBehaviour
{
    public GameObject player;
    private void OnTriggerEnter(Collider other)
    {
        void Start()
        {

            this.gameObject.SetActive(true);
        }
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("当たった");
            //Destroy(this.gameObject);
            this.gameObject.SetActive(false);

        }
    }
}
