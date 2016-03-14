using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class AIPlayer : MonoBehaviour {
    //Holds the players current score, their progress bar, their delta score, their total score.
     float playerDelta = 0.0f;            //The amount added on each button press, if in scoreattack mode the delta is 10 by default.
    public  float score = 0;                     //Score, used for both score and to handle scale (scale becomes score/1000)
    public GameObject headTexture;
    public Text scoreText;
    public GameObject headSprite;
    public GameObject LeftArrow;
    public GameObject RightArrow;
    public float pressRateHz = 5.0f;        //Rate of random press attempts
    public float presssRateProb = 1.0f;      //if 1.0 the ai will always press the correct button
    public GameObject Body;
    public GameObject[] heads;
    Animator body;
    float pressTimer; 
    Animator leftArrow;
    Animator rightArrow;
    bool currentArrow = false;      //false means left is lit, right means right is lit
    bool playing = false;
    bool pressFlag = false; //if this flag is true then the ai will attempt to press a key
    float currentStirSpeed = 0.5f;
    public bool readDifficultyFromPlayerPrefs = true;

    // Use this for initialization
    void Start () {
        leftArrow = LeftArrow.GetComponent<Animator>();
        rightArrow = RightArrow.GetComponent<Animator>();
        body = Body.GetComponent<Animator>();
        if (readDifficultyFromPlayerPrefs)
        {
            pressRateHz = (PlayerPrefs.GetInt("diff", 0) + 1) * 5;
            presssRateProb = Mathf.Clamp01(PlayerPrefs.GetInt("diff",0)*0.2f);
        }
        pressTimer = 1 / pressRateHz;
        if (headTexture.GetComponent<SpriteRenderer>().sprite == null)
        {
            int headUsed = Mathf.Abs(Mathf.RoundToInt(Random.insideUnitCircle.x * ((float)(heads.Length - 1))));
            Debug.Log(headUsed);
            headTexture.GetComponent<SpriteRenderer>().sprite = heads[headUsed].GetComponent<SpriteRenderer>().sprite;
        }
        else
        {
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
            if ((pressTimer -= Time.deltaTime) <= 0)
            {
                float x = Random.insideUnitCircle.x;
                if(x < presssRateProb)
                {
                    score += 10f;
                    currentArrow = !currentArrow;
                    currentStirSpeed = Mathf.Clamp01(currentStirSpeed + 0.1f);            
                }
                else
                {
                    currentStirSpeed = Mathf.Clamp01(currentStirSpeed + 0.1f);
                }
                pressTimer = 1/pressRateHz;
            }
            rightArrow.SetBool("isActive", !currentArrow);
            leftArrow.SetBool("isActive", currentArrow);
            body.speed = currentStirSpeed;
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
