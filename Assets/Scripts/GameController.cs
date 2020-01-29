using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public Text scoreText;
    public Text livesText;
    public Text gameOver;
    public static int score;
    public int lives;


    public GameObject menuButton, quitButton, mouse1, mouse2, mouse3, player;

    //private PlayerMovement playerMovement;


    void Start()
    {
        score = 0;
        lives = 3;
        gameOver.text = "";
        SetGameover();

        menuButton.SetActive(false);
        quitButton.SetActive(false);

        mouse1.SetActive(true);
        mouse2.SetActive(true);
        mouse3.SetActive(true);

    }

    void Update()
    {

        if (Input.GetKey("escape"))
            Application.Quit();
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    public void UpdateScore()
    {
        
        scoreText.text = "High Score" + score;
        SetGameover();

    }
   

    public void UpdateLives()
    {

        if (lives > 3)
              lives = 3;

          switch (lives)
          {
              case 3:
                  mouse1.SetActive(true);
                  mouse2.SetActive(true);
                  mouse3.SetActive(true);
                  break;

              case 2:
                  mouse1.SetActive(true);
                  mouse2.SetActive(true);
                  mouse3.SetActive(false);
                  break;

              case 1:
                  mouse1.SetActive(true);
                  mouse2.SetActive(false);
                  mouse3.SetActive(false);
                  break;

              case 0:
                  mouse1.SetActive(false);
                  mouse2.SetActive(false);
                  mouse3.SetActive(false);
                  break;
          }
    }

    public void SetGameover()
    {
        //if() level complete amoutn of slices collected

        if(lives == 0)
        {
            gameOver.text = "GAME OVER";
            menuButton.SetActive(true);
            quitButton.SetActive(true);
        }
    }
}
