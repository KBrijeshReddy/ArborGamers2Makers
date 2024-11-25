using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StopWatch : MonoBehaviour
{
    static public float min;
    static public float sec;

    [SerializeField] private TMP_Text text;

    private string minStr;
    private string secStr;

    void Start()
    {
        min = 0;
        sec = 0;
    }

    void Update()
    {
        if ((int)sec >= 60)
        {
            sec = 0;
            min += 1;
        }

        if (sec < 10)
        {
            secStr = "0" + ((int)sec).ToString();
        }
        else
        {
            secStr = ((int)sec).ToString();
        }

        if (min < 10)
        {
            minStr = "0" + ((int)min).ToString();
        }
        else
        {
            minStr = ((int)min).ToString();
        }

        text.text = minStr + ":" + secStr;
    }

    void FixedUpdate()
    {
            sec += Time.deltaTime;
    }
}
