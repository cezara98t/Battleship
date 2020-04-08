using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartManager : MonoBehaviour
{
    [SerializeField]
    private Text username;
    [SerializeField]
    private Text error;

    public void startGame() {
        //username deja exista
        string response = RestClient.Instance.getUsername(username.text);
        if ( response.Length>0) {
            error.text = "Username " + username.text + " already exists!";
            return; }

        GameData.username = username.text;
        Application.LoadLevel("ChooseBoard");
    }
}
