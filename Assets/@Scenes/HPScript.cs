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
    private float HP = 10f;
    // Start is called before the first frame update
    void Start()
    {
        setSlider = slider.GetComponent<Slider>();

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
    }
}
