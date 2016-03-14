using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FlashComponent : MonoBehaviour
{
    public Color flashColor = Color.red;
    public Color hideColor = Color.black;
    public bool hideFlash = false;
    public float flashRateHz = 100.0f;
    bool switchedOn = true;
    bool flag = true;
    float timer;
    string theText = "";
    // Use this for initialization
    void Start()
    {
        timer = 1 / flashRateHz;
        Text thisObjAsText = gameObject.GetComponent<Text>();
        theText = thisObjAsText.text;
    }

    // Update is called once per frame
    void Update()
    {
        if (switchedOn)
        {
            if ((timer -= Time.deltaTime) <= 0)
            {
                if (hideFlash)
                {
                    Text thisObjAsText = gameObject.GetComponent<Text>();
                    if (flag)
                    {
                        thisObjAsText.text = "";
                    }
                    else { thisObjAsText.text = theText; }
                }
                else
                {
                    Text thisObjAsText = gameObject.GetComponent<Text>();
                    if (thisObjAsText != null)
                    {
                        if (flag)
                        {
                            thisObjAsText.color = flashColor;
                        }
                        else
                        {
                            thisObjAsText.color = hideColor;
                        }
                    }
                }
                flag = !flag;
                timer = 1 / flashRateHz;
            }

        }
    }

   public void enable()
    {
        switchedOn = true;

    }
   public void disable()
    {
        switchedOn = false;
    }
}
