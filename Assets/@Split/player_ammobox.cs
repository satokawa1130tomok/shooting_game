using UnityEngine;

public class player_ammobox : MonoBehaviour
{
    private int Random_;

    public GameObject ammobox;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ammobox = GameObject.FindWithTag("ammo_box");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject == ammobox)
        {
            Destroy(ammobox);
            Random_ = Random.Range(30, 100);
            player.bulletcount = Random_;

            Debug.Log("player_ammobox");
        }
    }
} 
