using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private GameObject target;
    NavMeshAgent agent;
    public GameObject EnemyBullet;
    public GameObject generator;
    public game_generator gg;
    public int EnemyHP;


[SerializeField]
    private float bulletSeed = 5000;
    Vector3 force;
    public float distance;



    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        InvokeRepeating("EnemyAttack", 1, 1);
        //target = GameObject.Find("Tank");
        //target = gameobject.findwithtag("pl");
        //generator = gameobject.find("generator");
        //gg = generator.GetComponent<game_generator>();
        EnemyHP = 5;

    }
    void Update()
    {
 
      
        if (EnemyHP == 0)
        {
            gg.enemycount++;
            Destroy(this.gameObject);
        }
        if (distance < 120)
        {
            agent.enabled = true;
            
        }
        else
        {
            agent.enabled = false;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            EnemyHP--;
            //Debug.Log("hit");

        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            EnemyHP--;
            //Debug.Log("hit");

        }
    }
    void EnemyAttack()
    {
        
        if (distance<60)
        {
            
      
           GameObject enemyBullets = Instantiate(EnemyBullet) as GameObject;
           enemyBullets.transform.position = this.transform.position;
           force = this.gameObject.transform.forward * bulletSeed;
           enemyBullets.GetComponent<Rigidbody>().AddForce(force);
           Destroy(enemyBullets.gameObject, 4);
        }
        
    }
}





