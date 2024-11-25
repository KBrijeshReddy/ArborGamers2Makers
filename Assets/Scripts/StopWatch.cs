using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StopWatch : MonoBehaviour
{
    public static StopWatch instance; void Awake() { instance = this; }
    public static float min;
    public static float sec;
    public static float totalSec;

    [SerializeField]
    private TMP_Text text;
    [SerializeField]
    private bool countDown;

    private string minStr;
    private string secStr;

    public void ResetTimer(bool start = false)
    {
        if (start)
        {
            totalSec = 0;
        }
        else
        {
            totalSec += 60*min + sec;
        }

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
        if (countDown)
        sec += Time.deltaTime;
    }
}
