using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class handleExit : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

}

    void onTriggerEnter2D(Collider2D collider)
    {
        SceneManager.LoadScene("worldMap");

    }
}
