using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HPScript : MonoBehaviour
{
    private Slider setSlider;
    public GameObject slider;
    [SerializeField]
    private float HP = 20f;
    public GameObject Portion_clone;
    // Start is called before the first frame update
    void Start()
    {
        setSlider = slider.GetComponent<Slider>();

        Portion_clone.gameObject.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        setSlider.value = HP;

        //Debug.Log(HP);

        if(HP<=0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "EnemyBullet")
        {
            HP--;
        }
        if(other.gameObject.tag  == "potion")
        {
            HP =+10;

            Portion_clone.gameObject.SetActive(false);


        }
    }
  

}
