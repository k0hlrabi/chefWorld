using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class MainMenu : MonoBehaviour {
    public float cursorSpacing = 10f;
    int currentSelection = 0;
    public GameObject cursor;
    public GameObject menuHolder;
    bool inMenu = false;
    bool inHelp = false;
    Vector3 initalCursorPosition;
    bool buttonDown = false;
    public Text enterText;
    public GameObject helpText;
    GameObject[] menuTexts;
	// Use this for initialization
	void Start () {
        menuHolder.SetActive(false);
       cursor.SetActive(false);
        initalCursorPosition = cursor.transform.position;
        menuTexts = GameObject.FindGameObjectsWithTag("menuText");
        foreach (GameObject item in menuTexts)
        {
            item.SetActive(false);
        }

        helpText.SetActive(false);


	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Select") && !buttonDown)
        {
            Debug.Log(inHelp);
            buttonDown = true;
            if (!inMenu)
            {
                foreach (GameObject item in menuTexts)
                {
                    item.SetActive(true);
                }
                inMenu = true;
                menuHolder.SetActive(true);
                cursor.SetActive(true);
                enterText.text = "";
            }
            else
            {
                switch (currentSelection)
                {
                    case 0:
                        SceneManager.LoadScene("worldMap");
                        break;
                    case 1:
                        SceneManager.LoadScene("selectionScreen");
                        break;
                    case 2:
                        if (inHelp)
                        {
                            inHelp = !inHelp;
                            helpText.SetActive(false);
                            menuHolder.SetActive(true);
                        }
                        else {
                            inHelp = !inHelp;
                            menuHolder.SetActive(false);
                            helpText.SetActive(true);
                        }
                        break;
                    case 3:
                        //exit the program
                        break;
                }
            }
        }
        if (!inHelp && inMenu)
        {
            if (Input.GetAxis("Vertical") > 0 && !buttonDown)
            {
                currentSelection--;
                buttonDown = true;
            }
            if (Input.GetAxis("Vertical") < 0 && !buttonDown)
            {
                currentSelection++;
                buttonDown = true;
            }
            if (currentSelection > 3)
            {
                currentSelection = 0;
            }
            if (currentSelection < 0)
            {
                currentSelection = 3;
            }
            cursor.transform.position = initalCursorPosition - new Vector3(0, currentSelection * cursorSpacing);
        }
        if (Input.GetAxis("Vertical") == 0 && Input.GetAxis("Select") == 0)
        {
            buttonDown = false;
        }
    }
}
