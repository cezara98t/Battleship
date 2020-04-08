using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public GameObject player_board;
    public GameObject opponent_board;
    public GameObject stop_from_clicking;
    public Text score;
    public Text winner;
    public Text opponent_name;
    public Text username;

    public Button thiefButton;

    public GameObject buttonPrefab;
    private Grid player_grid;
    private Grid oppoent_grid;
    private bool gameEnded = false;
    void Start()
    {
        player_grid = new Grid(buttonPrefab, player_board, 2,null);
        stop_from_clicking.SetActive(true);
        oppoent_grid = new Grid(buttonPrefab, opponent_board, 1,stop_from_clicking);
        username.text = "You are " + GameData.username;
        
    }

    void Update()
    {
       score.text = "Score: "+GameData.score;
    }
    private void FixedUpdate()
    {
        verifyOpponent();
        verifyTurn();
        verifyEndOfGame();
    }

    private void verifyEndOfGame()
    {
        if (GameData.gold == GameData.toSelect && gameEnded == false)
        {
            gameEnded = true;
            RestClient.Instance.postWinner(GameData.username);
            thiefButton.gameObject.SetActive(true);
        }
        string winner = JsonConvert.DeserializeObject<Board>(RestClient.Instance.getUsername(GameData.username)).winner;
        if (winner.Length > 0)
        {
            stop_from_clicking.SetActive(true);
            this.winner.text = "Game over!\n" + winner + " won the game";
        }

    }

    private void verifyTurn()
    {
        bool myTurn = JsonConvert.DeserializeObject<Board>(RestClient.Instance.getUsername(GameData.username)).turn;
        if (myTurn == true)
            stop_from_clicking.SetActive(false);
        else
            stop_from_clicking.SetActive(true);
    }

    void verifyOpponent()
    {
        string opponent = JsonConvert.DeserializeObject<Board>(RestClient.Instance.getUsername(GameData.username)).opponent;
        if (opponent != null) {
            GameData.opponent = opponent;
            opponent_name.text = opponent;
        }
    }

    public void runWithTheMoney()
    {
        Application.LoadLevel("Run");
    }
}
