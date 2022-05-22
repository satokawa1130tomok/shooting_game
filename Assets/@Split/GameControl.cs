using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameControl : MonoBehaviour
{
    public Text TextFrame;
    private player player;

    // Start is called before the first frame update
    void Start()
    {
        TextFrame = GameObject.FindGameObjectWithTag("bulletcount").GetComponent<Text>();
        player = GetComponent<player>();
        
    }

    // Update is called once per frame
    void Update()
    {
        TextFrame.text = player.bulletcount.ToString();
    }
}
