using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class QuizGame : MonoBehaviour
{
    public GameObject[] images;
    int currentLevel;
    [SerializeField] public GameObject _object;
    [SerializeField] public GameObject timerO;


    [SerializeField] public AudioSource SFXSource;
    [SerializeField] public AudioSource MusicSource;

    

    public AudioClip backGround;
    public AudioClip correctAnswerSFX;
    public AudioClip noCorrectAnswerSFX;

    private Timer timer;
    private Score score;
    

    private void Start()
    {
        
        
        score = FindObjectOfType<Score>();
        timer = FindObjectOfType<Timer>();

    }

    public void correctAnswer()
    {
        SFXSource.clip = correctAnswerSFX;
        SFXSource.Play();
        score.Animate();
        _object.GetComponent<Animator>().SetTrigger("win");
        UpdateLevel();
    }

    public void NoCorrectAnswer()
    {
        SFXSource.clip = noCorrectAnswerSFX;
        SFXSource.Play();
        _object.GetComponent<Animator>().SetTrigger("lose");
        UpdateLevel();
    }

    private void UpdateLevel()
    {
        StartCoroutine(Transition());
        timerO.SetActive(true);
        timer.startTime = 5f;
    }

    private IEnumerator Transition()
    {

        if (currentLevel + 1 != images.Length)
        {
            images[currentLevel].SetActive(false);
            currentLevel++;
            yield return new WaitForSeconds(5f);
            timerO.SetActive(false);
            images[currentLevel].SetActive(true);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}

