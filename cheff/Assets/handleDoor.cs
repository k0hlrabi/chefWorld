using UnityEngine;
using System.Collections;

public class handleDoor : MonoBehaviour {

    GameObject thoughtBubble;

	// Use this for initialization
	void Start () {
        thoughtBubble = GameObject.Find("thoughtBubble");
        
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        
            thoughtBubble.SetActive(true);
        
       // Debug.Log("HIT");


    }
    void OnTriggerExit2D(Collider2D other)
    {
        thoughtBubble.SetActive(false);


    }
}
