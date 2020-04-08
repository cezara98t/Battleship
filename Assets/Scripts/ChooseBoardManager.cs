using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseBoardManager : MonoBehaviour
{

    public GameObject containter;
    public GameObject buttonPrefab;
    public Text squares_text;
    public Text greeting_text;


    private Grid grid;
    void Start()
    {
        greeting_text.text = "Hello, "+GameData.username+"!";
        grid = new Grid(buttonPrefab, containter,0,null);
    }

    private void Update()
    {
        squares_text.text = "You have to select " + grid.squaresToSelect + " squares.";
        if (grid.squaresToSelect == 0) {
            StartCoroutine("stop");
        }
    }

    private IEnumerator stop()
    {
        GameData.player_poitions = grid.positions;
        foreach (Button go in containter.GetComponentsInChildren<Button>())
        {
            go.interactable = false;
        }

        yield return new WaitForSeconds(1);

        Board boardToAdd = new Board(GameData.username, GameData.player_poitions);
        RestClient.Instance.addBoard(boardToAdd);

        Application.LoadLevel("Game");
    }


}
