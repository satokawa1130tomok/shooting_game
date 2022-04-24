using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Photon.Pun;
using Photon.Realtime;

public class NameInputFieldScript : MonoBehaviour
{
    static string playerNamePrefKey = "playerName";

    private void Start()
    {
        string defaultName = " ";
        InputField _inputField = this.GetComponent<InputField>();

        if (_inputField != null)
        {
            if (PlayerPrefs.HasKey(playerNamePrefKey))
            {
                defaultName = PlayerPrefs.GetString(playerNamePrefKey);
                _inputField.text = defaultName;
            }
        }

    }
    public void SetPlayName(string value)
    {
        PhotonNetwork.NickName = value + " ";
        PlayerPrefs.SetString(playerNamePrefKey, value);

        Debug.Log(PhotonNetwork.NickName);

    }
    

}