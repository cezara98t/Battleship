using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    float runSpeed = 1;
    float horizontalMove = 0;
    public CircleCollider2D playerCollider;
    public BoxCollider2D finish;
    public GameObject walls;
    public GameObject wonPanel;
    public Text score;
    public GameObject gold;

    private void Start()
    {
        score.text = "Score: " + GameData.score;
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
            transform.Translate(Vector3.left * runSpeed * Time.deltaTime);
        if(Input.GetKey(KeyCode.RightArrow))
            transform.Translate(Vector3.right * runSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.UpArrow))
            transform.Translate(Vector3.up * runSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.DownArrow))
            transform.Translate(Vector3.down * runSpeed * Time.deltaTime);

        foreach (Image img in walls.GetComponentsInChildren<Image>())
        {
            if (playerCollider.IsTouching(img.GetComponentInChildren<BoxCollider2D>()))
            {
                transform.position = new Vector3(-4.5f, 3.8f, 90);
                GameData.score = (int)(GameData.score * 0.9);
                score.text = "Score: " + GameData.score;
            }
        }

        if (playerCollider.IsTouching(finish))
        {
            wonPanel.SetActive(true);
        }
        if (playerCollider.IsTouching(gold.GetComponent<CircleCollider2D>()))
        {
            GameData.score = GameData.score * 2;
            score.text = "Score: " + GameData.score;
            gold.SetActive(false);
        }


    }
}
