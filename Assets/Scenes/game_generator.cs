using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class game_generator : MonoBehaviour
{
    public GameObject ClearText;
    public int enemycount;
    void Start()

    {
        ClearText.GetComponent<Text>().enabled = false;
        enemycount = 0;
    }
    void Update()
    {
        if(enemycount == 3)
        {
            GameClear();

        }
    }
    void GameClear()
    {
        ClearText.GetComponent<Text>().enabled = true;
        SceneManager.LoadScene("Start screen");
    }
    void GameOver()
    {
        SceneManager.LoadScene("Gameover");
    }
}
