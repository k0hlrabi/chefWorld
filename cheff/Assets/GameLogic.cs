using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour {

    public string enemyName = "NoNameSelected";
    public string enemyLocation = "NoLocationSelected";
    public bool multiplayer = false;
    public float CountDownTime = 3.0f;
    public float GameTime = 30.0f;
    public Sprite Background;
    public Text countDownText;
    public Text gameTimeText;
    public Text winText;
    public Text restartText;
    public Player player1;
    public Player player2;
    public bool StoryGame = false;
    bool playing = false;
    bool countingDown = true;
    bool endGame = false;
    bool seasoning = false;
    int winner = -1;
    float countDownTimer;
    float gameTimer;

    // Use this for initialization
    void Start () {
         countDownTimer = CountDownTime;
        gameTimer = GameTime;
        countDownText.gameObject.SetActive(true);
        gameTimeText.gameObject.SetActive(false);
        winText.gameObject.SetActive(false);
        restartText.gameObject.SetActive(false);
        player1.disable();
        player2.disable();
        countingDown = true;
    }

    // Update is called once per frame
    void Update () {
        if (countingDown)
        {
            if ((countDownTimer -= Time.deltaTime) < 0)
            {
                if (countDownTimer > -5)
                {
                    countDownText.text = "GO!";
                    playing = true;
                    gameTimeText.gameObject.SetActive(true);

                }
                else {
                    countingDown = false;
                    countDownText.gameObject.SetActive(false);
                }
            }
            else
            {
                countDownText.text = "Get Ready! \n " + countDownTimer.ToString("F2");
            }
        }

        if (playing)
        {
            player1.enable();
            player2.enable();
            gameTimer -= Time.deltaTime;
            if (gameTimer < 0)
            {
                playing = false;
                endGame = true;
                gameTimeText.text = "Game Over!!!";
                player1.disable();
                player2.disable();
                if (player1.score > player2.score)
                {
                    winner = 1;
                }
                else if (player2.score > player1.score)
                {
                    winner = 2;
                }
                else
                {
                    winner = 3;
                }
            }
            else
            {
                
                    gameTimeText.text = "Time Left: " + gameTimer.ToString("F2");

            } 
        }else if (endGame)
        {
            winText.gameObject.SetActive(true);
            restartText.gameObject.SetActive(true);
            switch (winner) { 
                case 1:
                    if (StoryGame)
                    {
                        winText.text = "CHEF WINS!";
                    }
                    else {
                        winText.text = "PLAYER 1 WINS!";
                    }
                break;
                case 2:
                    if (StoryGame)
                    {
                        winText.text = "CHEF LOST!" ;
                    }
                    else
                    {
                winText.text = "PLAYER 2 WINS!";
                    }
                
                break;
                case 3:
                winText.text = "You're all losers!";
                 break;
            }
            if (Input.GetAxis("Select") > 0)
            {
                countDownTimer = CountDownTime;
                gameTimer = GameTime;
                countDownText.gameObject.SetActive(true);
                if (StoryGame)
                {

                    restartText.text = "Press Enter for Next Level!";
                }
                gameTimeText.gameObject.SetActive(false);
                winText.gameObject.SetActive(false);
                restartText.gameObject.SetActive(false);
                player1.disable();
                player2.disable();
                countingDown = true;
                endGame = false;
                playing = false;
            }else if(Input.GetAxis("Back") > 0)
            {
                SceneManager.LoadScene("mainMenu");
            }

        }

        

	
	}
}


