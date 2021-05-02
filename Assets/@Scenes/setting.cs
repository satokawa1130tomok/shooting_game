using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
　
public class NewBehaviourScript : MonoBehaviour
{
    public Canvas setting;
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(true);
        setting.gameObject.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {
        //if(gameObject.GetComponent<Button>().onClick.AddListener())
        //{
        //    this.gameObject.SetActive(false);
        //    setting.gameObject.SetActive(true);
        //}
    }
}
