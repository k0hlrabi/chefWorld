using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class butlerCrazyShit : MonoBehaviour {
    public GameLogicAI gamelog;
    public GameObject theButler;
    public GameObject buttler2;
    int direction = 1;
   // Use this for initialization

    List<float> times = new List<float>();
    List<float> timers = new List<float>();
    void Start () {
        theButler.SetActive(true);
        times.Add(5f);
        times.Add(7f);
        times.Add(0.5f);
        for (int x = 0; x < times.Count; x++)
        {
            timers.Add(times[x]);
        }
    }

    // Update is called once per frame
    void Update() {
        if (gamelog.getIfActive())
        {
            for (int x = 0; x < timers.Count; x++)
            {
                if ((timers[x] -= Time.deltaTime) <= 0)
                {
                    switch (x)
                    {
                        case 0:
                            Instantiate(theButler, transform.position, Quaternion.identity);
                            Debug.Log("HIT");
                            
                            break;
                        case 1:
                            Instantiate(buttler2, Vector3.zero, Quaternion.identity);
                            break;
                        case 2:
                            if(transform.position.x > 1|| transform.position.x < -1)
                            {
                                direction *= -1;
                            }
                            transform.Translate(new Vector3(3*direction, 3*direction));
                            break;

                    }
                    timers[x] = times[x];

                }
              
            }
        }
            
        }
    }


