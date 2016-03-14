using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterSelect : MonoBehaviour {

    // Use this for initialization

    public GameObject player1Cursor;
    public GameObject player2Cursor;
    public GameObject player1head;
    public GameObject player2head;
    public GameObject player2Avatar;
    public Text player2Text;
    public GameObject[] selectors;
    public Text readyText;
    bool player2ButtonDown = false;
    bool player1ButtonDown = false;
    bool player1Chosen = false;
    bool player2Chosen = false;
    bool multiplayer = false;
    bool readyToSwitch = false;
    int currentSelect1 = 0;
    int currentSelect2 = 1;
    //Difficulty Menu
    public GameObject DifficultyMenu;
    public GameObject DifficultyMenuCursor;
   
    bool inDiffMenu = false;
    int difficultySelection = 0;

    void Start () {
        player2head.SetActive(false);
        player2Cursor.SetActive(false);
        player2Avatar.SetActive(false);
        player1Cursor.transform.position = selectors[0].transform.position;
        FlashComponent flasher = player2Text.GetComponent<FlashComponent>();
        flasher.enable();
        DifficultyMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
        if (inDiffMenu)
        {
            if (!player1ButtonDown)
            {
                if (Input.GetAxisRaw("Vertical") > 0)
                {
                    player1ButtonDown = true;
                    if (--difficultySelection < 0)
                    {
                        difficultySelection = 3;
                        DifficultyMenuCursor.transform.Translate(new Vector3(0, -3));
                    }
                    else
                    {
                        DifficultyMenuCursor.transform.Translate(new Vector3(0, 1));

                    }
                }
                else if (Input.GetAxisRaw("Vertical") < 0) {
                    player1ButtonDown = true;
                    if (++difficultySelection > 3 )
                    {
                        difficultySelection = 0;
                        DifficultyMenuCursor.transform.Translate(new Vector3(0, 3));
                    }
                    else
                    {
                        DifficultyMenuCursor.transform.Translate(new Vector3(0, -1));
                    }
                }
                else if (Input.GetAxis("Select") > 0)
                {
                    PlayerPrefs.SetInt("diff", difficultySelection);
                    PlayerPrefs.SetInt("Player1Avatar", currentSelect1);
                    SceneManager.LoadScene("battleScreenAI");
                }
            }
            if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0 && Input.GetAxisRaw("Select") == 0)
            {
                player1ButtonDown = false;
            }



        }
        else {
            if (Input.GetAxisRaw("Back") > 0)
            {
                multiplayer = false;
                player2head.SetActive(false);
                player2Cursor.SetActive(false);
                player2Avatar.SetActive(false);
                FlashComponent flasher = player2Text.GetComponent<FlashComponent>();
                flasher.enable();
                player2Text.text = "Press Space!!";
                player1ButtonDown = true;
                readyToSwitch = false;
            }
            if (Input.GetAxisRaw("Select2") > 0 && !multiplayer && !player2ButtonDown)
            {
                multiplayer = true;
                player2head.SetActive(true);
                player2Cursor.SetActive(true);
                player2Avatar.SetActive(true);
                FlashComponent flasher = player2Text.GetComponent<FlashComponent>();
                flasher.disable();
                player2Text.text = " ";
                player2ButtonDown = true;
            }
            else if (multiplayer && Input.GetAxisRaw("Select2") > 0 && !player2ButtonDown)
            {
                player2ButtonDown = true;
                if (!player2Chosen)
                {
                    player2Chosen = true;
                }
            }
            if (Input.GetAxisRaw("Select") > 0 && !player1ButtonDown)
            {
                player1ButtonDown = true;
                if (!multiplayer)
                {
                    DifficultyMenu.SetActive(true);
                    inDiffMenu = true;
                }
                else if (!player1Chosen)
                {
                    player1Chosen = true;
                }
                else if (player1Chosen && player2Chosen && readyToSwitch)
                {
                    PlayerPrefs.SetInt("Player1Avatar", currentSelect1);
                    PlayerPrefs.SetInt("Player2Avatar", currentSelect2);

                    SceneManager.LoadScene("battleScreen");
                }
            }

            if (player1Chosen && player2Chosen)
            {
                readyToSwitch = true;
                readyText.text = "Ready? \n (Press Enter)";

            }


            if (Input.GetAxisRaw("Horizontal") > 0 && !player1ButtonDown && !player1Chosen)
            {
                player1ButtonDown = true;
                if (++currentSelect1 > 13)
                {
                    currentSelect1 = 0;
                }
            }
            if (Input.GetAxisRaw("Horizontal") < 0 && !player1ButtonDown && !player1Chosen)
            {
                player1ButtonDown = true;
                if (--currentSelect1 < 0)
                {
                    currentSelect1 = 13;
                }
            }
            if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0 && Input.GetAxisRaw("Select") == 0)
            {
                player1ButtonDown = false;
            }
            if (Input.GetAxisRaw("Vertical") > 0 && !player1ButtonDown && !player1Chosen)
            {
                player1ButtonDown = true;
                currentSelect1 += 7;
                if (currentSelect1 > 13)
                {
                    currentSelect1 = currentSelect1 - 14;
                }
            }
            if (Input.GetAxisRaw("Vertical") < 0 && !player1ButtonDown && !player1Chosen)
            {
                player1ButtonDown = true;
                currentSelect1 -= 7;
                if (currentSelect1 < 0)
                {
                    currentSelect1 = 14 + currentSelect1;
                }
            }
            player1Cursor.transform.position = selectors[currentSelect1].transform.position;


            if (multiplayer)
            {

                if (Input.GetAxisRaw("Horizontal2") > 0 && !player2ButtonDown && !player2Chosen)
                {
                    Debug.Log("PRESSED");
                    player2ButtonDown = true;
                    if (++currentSelect2 > 13)
                    {
                        currentSelect2 = 0;
                    }
                }
                if (Input.GetAxisRaw("Horizontal2") < 0 && !player2ButtonDown && !player2Chosen)
                {
                    Debug.Log("PRESSED");
                    player2ButtonDown = true;
                    if (--currentSelect2 < 0)
                    {
                        currentSelect2 = 13;
                    }
                }
                if (Input.GetAxisRaw("Horizontal2") == 0 && Input.GetAxisRaw("Vertical2") == 0 && Input.GetAxisRaw("Select2") == 0)
                {
                    player2ButtonDown = false;
                }
                if (Input.GetAxisRaw("Vertical2") > 0 && !player2ButtonDown && !player2Chosen)
                {
                    player2ButtonDown = true;
                    currentSelect2 += 7;
                    if (currentSelect2 > 13)
                    {
                        currentSelect2 = currentSelect2 - 14;
                    }

                }
                if (Input.GetAxisRaw("Vertical2") < 0 && !player2ButtonDown && !player2Chosen)
                {
                    player2ButtonDown = true;
                    currentSelect2 -= 7;
                    if (currentSelect2 < 0)
                    {
                        currentSelect2 = 14 + currentSelect2;
                    }
                }
                player2Cursor.transform.position = selectors[currentSelect2].transform.position;

            }

            player1head.GetComponent<SpriteRenderer>().sprite = selectors[currentSelect1].GetComponent<SpriteRenderer>().sprite;
            Debug.Log(selectors[currentSelect1].GetComponent<SpriteRenderer>().sprite);
            if (multiplayer)
            {
                player2head.GetComponent<SpriteRenderer>().sprite = selectors[currentSelect2].GetComponent<SpriteRenderer>().sprite;

            }

        }


    }



}
