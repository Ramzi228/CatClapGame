using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Timer : MonoBehaviour
{
    public float startTime = 5;
    public Text timerLabel;

    void Start()
    {
        timerLabel.text = startTime.ToString();
    }

    void Update()
    {
        startTime -= Time.deltaTime;
        timerLabel.text = Mathf.Round(startTime).ToString();
    }
}
