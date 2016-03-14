using UnityEngine;
using System.Collections;

public class theButler : MonoBehaviour {


    float currentAngle = 0f;
    Vector2 startingPos;

	// Use this for initialization
	void Start () {
        startingPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(new Vector3(0.01f * Mathf.Cos(currentAngle), 0.01f * Mathf.Sin(currentAngle)));
        currentAngle += 3.14f / 180;
	}
}
