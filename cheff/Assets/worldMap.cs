using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class worldMap : MonoBehaviour {

    int current = 0;
    List<GameObject> mapPoints = new List<GameObject>();
    List<string> cityNames = new List<string>();
    Vector3 nextPosition = new Vector3();
    Vector3 currentPosition = new Vector3();
    List<string> sceneNames = new List<string>();
    float timer = 0.0f;
    public float speed = 10;
    public float mapChangeRate = 100.0f;  //Rate of change in hz
    GameObject chefHead;
    Vector3 deltaPos = new Vector3();
    bool moving = false;
    Text cityName;

	// Use this for initialization
	void Start () {
        mapPoints.Add(GameObject.Find("nova"));
        mapPoints.Add(GameObject.Find("shall"));
        mapPoints.Add(GameObject.Find("sjohns"));
        mapPoints.Add(GameObject.Find("providence"));
        mapPoints.Add(GameObject.Find("depaul"));
        mapPoints.Add(GameObject.Find("marquette"));
        mapPoints.Add(GameObject.Find("creighton"));
        mapPoints.Add(GameObject.Find("butler"));
        mapPoints.Add(GameObject.Find("xavier"));
        mapPoints.Add(GameObject.Find("gtown"));
        cityNames.Add("Nova");
        cityNames.Add("Seton");
        cityNames.Add("Johnz");
        cityNames.Add("Provo");
        cityNames.Add("Pauli");
        cityNames.Add("market");
        cityNames.Add("Cray");
        cityNames.Add("Alfred");
        cityNames.Add("Dirty X");
        cityNames.Add("Evil Lair");
        sceneNames.Add("chefsHouseNova");
        sceneNames.Add("shall");
        sceneNames.Add("sjohnny");
        sceneNames.Add("provo");
        sceneNames.Add("thepaul");
        sceneNames.Add("theMarket");
        sceneNames.Add("craycray");
        sceneNames.Add("buttlerrrr");
        sceneNames.Add("xav");
        sceneNames.Add("gtown");
        chefHead = GameObject.Find("Chef");
        cityName = GameObject.Find("City").GetComponent<Text>();
        currentPosition = mapPoints[0].transform.position;
        timer = 1 / mapChangeRate;
        PlayerPrefs.SetInt("Player1Avatar", 2);
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetAxis("Horizontal") > 0 && !moving)
        {
            if (++current >= mapPoints.Count)
            {
                current = 0;
            }
            chefHead.transform.position = mapPoints[current].transform.position;
            cityName.text = cityNames[current];
            moving = true;
        }
        if (Input.GetAxis("Horizontal") < 0 && !moving)
        {
            if (--current < 0)
            {
                current = mapPoints.Count-1;
            }
            chefHead.transform.position = mapPoints[current].transform.position;
            cityName.text = cityNames[current];
            moving = true;
        }
        if (Input.GetAxis("Horizontal") == 0)
        {
            moving = false;
        }
        if (Input.GetButtonDown("Select"))
        {
            SceneManager.LoadScene(sceneNames[current]);
        }
    }

    bool compareVectors(Vector3 a, Vector3 b, float threshold)
    {
        if (Vector3.Equals(a, b))
        {
            return true;
        }
        else
        {
            if(Mathf.Abs(a.x-b.x) <=threshold && Mathf.Abs(a.z - b.z) <= threshold)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
