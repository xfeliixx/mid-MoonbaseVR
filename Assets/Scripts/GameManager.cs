using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //monitors the state of the game - used to track when the asteriods can be shot and scored...
    public enum GameState
    {
        Intro,
        Playing,
        GameOver
    }
    public static GameState eGameStatus;

    public delegate void AsteriodHandler();
    public static event AsteriodHandler AsteroidDestroyed;

    [Header("Game structure Events")]
    public UnityEvent onStartActivated;
    public UnityEvent OnGameOver;
    public UnityEvent OnGameReset;

    [Header("The Time Slider Components")]
    public Image sliderImg;
    public float gameDuration;
    private float sliderCurrentFillAmount = 1f;

    public static int playerScore = 0;

    private void Start()
    {
        eGameStatus = GameState.Intro;
    }

    private void Update()
    {
        //check what state the game is in
        if (eGameStatus == GameState.Playing)
        {
            sliderImg.fillAmount = (sliderCurrentFillAmount - (Time.deltaTime / gameDuration));

            sliderCurrentFillAmount = sliderImg.fillAmount;

            if(sliderCurrentFillAmount <= 0)
            {
                GameOver();
            }
        }
    }

    private void GameOver()
    {
        eGameStatus = GameState.GameOver;
        OnGameOver.Invoke();
    }

    public static void AsteroidHit(int scoreBonus)
    {
        
        if (eGameStatus == GameState.Playing)
        {
            playerScore += 10 * scoreBonus;
            AsteroidDestroyed();
        }
        else
        {
            Debug.Log("Not in Play mode!");
        }
    }

    public void StartGame()
    {
        eGameStatus = GameState.Playing;
        onStartActivated.Invoke();
    }

    public void ResetGame()
    {
        OnGameReset.Invoke();

        sliderCurrentFillAmount = 1f;
        playerScore = 0;
    }


    

}
