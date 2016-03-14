using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class Player : MonoBehaviour {
    //Holds the players current score, their progress bar, their delta score, their total score.
     float playerDelta = 0.0f;            //The amount added on each button press, if in scoreattack mode the delta is 10 by default.
    public float score = 0;                     //Score, used for both score and to handle scale (scale becomes score/1000)
    public string axis = "Horizontal";          //used to handle axis
    public Animation animator;
    public GameObject headTexture;
    public Text scoreText;
    public string InputAxis = "Horizontal";
    public GameObject LeftArrow;
    public GameObject RightArrow;
    public GameObject Body;
    public GameObject[] heads;
    public bool player2 = false;
    public float degradationTime = 0.5f;
    float degradationTimer;
    Animator body;
    Animator leftArrow;
    Animator rightArrow;
    float currentStirSpeed = 0.5f;
    bool currentArrow = false;      //false means left is lit, right means right is lit
    bool playing = false;
    float lastStirTime;

    // Use this for initialization
    void Start () {
        degradationTimer = degradationTime;
        leftArrow = LeftArrow.GetComponent<Animator>();
        rightArrow = RightArrow.GetComponent<Animator>();
        body = Body.GetComponent<Animator>();
        lastStirTime = -1f;
        if (!player2)
        {
           int head=  PlayerPrefs.GetInt("Player1Avatar",0);
            headTexture.GetComponent<SpriteRenderer>().sprite = heads[head].GetComponent<SpriteRenderer>().sprite;
        }
        else
        {
            int head = PlayerPrefs.GetInt("Player2Avatar", 0);
            headTexture.GetComponent<SpriteRenderer>().sprite = heads[head].GetComponent<SpriteRenderer>().sprite;
        }

                
    }
	
	// Update is called once per frame
	void Update () {
     
            if (playing)
            {
                    if (scoreText != null)
                    {
                        scoreText.text = "Score: " + score;
                    }
                    if ((Input.GetAxis(InputAxis)) > 0 && !currentArrow)
                    {
                        score += 10f;
                        currentArrow = !currentArrow;
                currentStirSpeed = Mathf.Clamp01(currentStirSpeed + 0.1f);
               

            }
            else if ((Input.GetAxis(InputAxis)) < 0 && currentArrow)
                    {
                        score += 10f;
                    currentArrow = !currentArrow;
                currentStirSpeed = Mathf.Clamp01(currentStirSpeed + 0.1f);
            }
            else 
            {
                if ((degradationTimer -= Time.deltaTime) < 0)
                {
                    currentStirSpeed = Mathf.Clamp01(currentStirSpeed - 0.1f);
                    degradationTimer = degradationTime;
                }
            }
           
            body.speed = currentStirSpeed;
            rightArrow.SetBool("isActive", !currentArrow);
           leftArrow.SetBool("isActive", currentArrow);
            
        }
	    
	}

    public void enable()
    {
        playing = true;

    }

    public void disable()
    {
        playing = false;
        score = 0;

    }
    public void pause()
    {
        playing = false;
    }

}
