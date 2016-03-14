using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class novaCrazyShit : MonoBehaviour {

    public GameLogicAI gamelog;
    public GameObject basketball;
    public GameObject BoomPos;
    public GameObject dog;
    ParticleSystem a;

    int direction = 1;
    List<float> times = new List<float>();
    List<float> timers = new List<float>();
	void Start () {
        a = BoomPos.GetComponent<ParticleSystem>();
        a.Stop();
            
        times.Add(1f);  //box movement
        times.Add(1f); //ball drop
        times.Add(5f); //fireworks
        times.Add(2f); //Dog
        times.Add(10f); //Strong Dog

        for(int x = 0; x < times.Count;x++)
        {
            timers.Add(times[x]);
        }	
	}

    void Update()
    {
        if (gamelog.getIfActive())
        {
            for (int x = 0; x < timers.Count; x++)
            {
                if ((timers[x] -= Time.deltaTime) < 0)
                {
                    switch (x)
                    {
                        case 0:
                            transform.Translate(new Vector3(1f * direction, 0));
                            if (transform.position.x > 7 || transform.position.x < -7)
                            {
                                transform.position = new Vector3(direction * 7f, transform.position.y);
                                direction *= -1;
                            }
                            break;
                        case 1:
                            Instantiate(basketball, transform.position, Quaternion.identity);
                            break;
                        case 2:
                            if (gamelog.player1.score > 1500)
                            {
                                a.Emit(200);
                            }
                            break;
                        case 3:
                            dog.GetComponentInChildren<Rigidbody2D>().AddForce(new Vector2(-5, 0), ForceMode2D.Impulse); 
                            if(dog.transform.position.x < -15)
                            {
                                dog.transform.position = new Vector2(-5, 0);

                            }
                            break;
                        case 4:
                            dog.GetComponentInChildren<Rigidbody2D>().AddForce(new Vector2(-100, 0), ForceMode2D.Impulse);
                            if (dog.transform.position.x < -15)
                            {
                                dog.transform.position = new Vector2(-5, 0);

                            }
                            break;

                    }
                    timers[x] = times[x];
                }

            }

        }
    }
}
