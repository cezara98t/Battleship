using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class Grid : MonoBehaviour
{
    public GameObject containter;
    public GameObject buttonPrefab;
    public GameObject stop_from_clicking;
    

    private int playerBoard=0;
    public List<int> positions;
    public int squaresToSelect = GameData.toSelect;

    public Grid(GameObject btnPrefab, GameObject cont, int board, GameObject stop) {
        buttonPrefab = btnPrefab;
        containter = cont;
        playerBoard = board;
        stop_from_clicking = stop;

        positions = new List<int>();

        for (int x = 0; x < 64; x++)
                createButton(x);
            
    }

    private void createButton(int x)
    {
        GameObject go = Instantiate(buttonPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        go.GetComponent<RectTransform>().sizeDelta = new Vector2(10, 20);
        if (playerBoard == 2)
        { //small player board
            go.transform.GetComponent<Button>().interactable = false;
            if (GameData.player_poitions.Contains(x))
            {
                go.transform.GetComponentInChildren<Text>().text = "G";
                go.transform.GetComponentInChildren<Text>().fontSize = 10;
            }
        }
        else
            go.transform.GetComponent<Button>().onClick.AddListener(delegate { clickButton(go, x); });

        go.transform.SetParent(containter.transform, false);
    }

    private void clickButton(GameObject go, int x)
    {
        if (playerBoard == 0)
        {
            if (go.GetComponentInChildren<Text>().text == "")
            {
                go.GetComponentInChildren<Text>().text = "GOLD";
                go.GetComponentInChildren<Text>().fontSize = 10;
                squaresToSelect--;
                positions.Add(x);
            }
            else
            {
                go.GetComponentInChildren<Text>().text = "";
                squaresToSelect++;
                positions.Remove(x);
            }
        }
        else if(playerBoard==1) {
            go.GetComponent<Button>().interactable = false;
           string response = RestClient.Instance.checkPos(x);
            if (response.Equals("1"))
            {
                go.GetComponentInChildren<Text>().text = "GOLD";
                go.GetComponentInChildren<Text>().color = Color.yellow;
                go.GetComponentInChildren<Text>().fontSize = 15;
                GameData.score+=10;
                GameData.gold++;
            }
            else
            {
                go.GetComponentInChildren<Text>().text = "X";
                go.GetComponentInChildren<Text>().color = Color.red;
                go.GetComponentInChildren<Text>().fontSize = 20;
                GameData.score--;
            }

        }
        else{ //e 2 cand e player board, dar nu poti modifica (cand e sus colt dreapta)

        }
    }


 
}

