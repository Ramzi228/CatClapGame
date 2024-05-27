using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YG;


public class Score : MonoBehaviour
{
    private Text scoreText;
    [SerializeField] private Text scoreTextFinal;
    [SerializeField] private Text recordText;

    private Animator animator;

    private float score;
    private float record;


    private void Start()
    {
        
        scoreText = GetComponent<Text>();
        animator = GetComponent<Animator>();
        record = PlayerPrefs.GetFloat("Record");
        YandexGame.NewLeaderboardScores("LeaderBoardScores", (int)record);

    }

    

    private void Update()
    {
        PlayerPrefs.SetFloat("Record", record);
        recordText.text = record.ToString();
        scoreText.text = score.ToString();
        scoreTextFinal.text = score.ToString();

        if (score > record)
        {

            record = score;

        }
    }

    public void Animate()
    {
        animator.SetTrigger("Play");
        score++;
    }

    

}
