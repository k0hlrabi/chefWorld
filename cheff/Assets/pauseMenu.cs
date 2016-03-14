using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour {
    public GameLogicAI gamelog;
    public GameLogic gameLogm;
    public GameObject pauseMenuHolder;
    public GameObject cursor;
    public bool multiplayer = false;
    public float cursorSpacing = 0f;
    public GameObject helpText;
    public GameObject helpBack;
    bool buttonDown = false;
    bool menuOpen = false;
    bool usable = false;
    bool inHelp = false;
    int currentSelection = 0;
    Vector3 initalCursorPosition = Vector3.zero;

	// Use this for initialization
	void Start () {
        pauseMenuHolder.SetActive(false);

        initalCursorPosition = cursor.transform.position;
        helpBack.SetActive(false);
        helpText.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if(!usable && gamelog.getIfActive())
        {
            usable = true;
        }
        if (usable)
        {
            if (Input.GetAxis("Back") > 0 && !buttonDown)
            {
                buttonDown = true;
                if (!multiplayer)
                {
                    if (!menuOpen)
                    {
                        menuOpen = true;
                        gamelog.pauseGame();
                        pauseMenuHolder.SetActive(true);
                    }
                    else
                    {
                        menuOpen = false;
                        gamelog.resumeGame();
                        pauseMenuHolder.SetActive(false);
                    }
                }
            }

            if (Input.GetAxis("Select") > 0 && !buttonDown && !inHelp)
            {
                buttonDown = true;
                switch (currentSelection)
                {
                    case 0:
                        menuOpen = false;
                        gamelog.resumeGame();
                        pauseMenuHolder.SetActive(false);
                        break;
                    case 1:
                        helpBack.SetActive(true);
                        helpText.SetActive(true);
                        inHelp = true;
                        break;
                    case 2:
                        SceneManager.LoadScene("worldMap");
                        break;
                }
            }else if(Input.GetAxis("Select") > 0 && !buttonDown && inHelp)
            {
                buttonDown = true;
                helpBack.SetActive(false);
                helpText.SetActive(false);
                inHelp = false;
            }


            if (Input.GetAxis("Vertical") < 0 && !buttonDown)
            {
                buttonDown = true;
                if (++currentSelection > 2)
                {
                    currentSelection = 0;
                }
            }
            if (Input.GetAxis("Vertical") > 0 && !buttonDown)
            {
                buttonDown = true;
                if (--currentSelection < 0)
                {
                    currentSelection = 2;
                }
            }
            if (Input.GetAxis("Vertical") == 0 && Input.GetAxis("Select") == 0 && Input.GetAxis("Back") == 0)
            {
                buttonDown = false;
            }
            cursor.transform.position = initalCursorPosition - new Vector3(0, currentSelection * cursorSpacing);
        }
    }
    
}
