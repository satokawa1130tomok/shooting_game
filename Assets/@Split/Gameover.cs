using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Gameover : MonoBehaviour
{
    public GameObject rst_button;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Button>();

    }

    // Update is called once per frame

    public void Onclick(int number)
    {
        switch (number)
        {
              case 1:
                SceneManager.LoadScene("Start screen");
                break;
        }
    }
}


