using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndScreen : MonoBehaviour
{
    [SerializeField]
    private TMP_Text text;

    void Start()
    {
        text.text = "THANKS FOR PLAYING \n YOU TOOK " + Mathf.Round(StopWatch.totalSec).ToString() + " SECONDS TO BEAT THE GAME";
    }
}
