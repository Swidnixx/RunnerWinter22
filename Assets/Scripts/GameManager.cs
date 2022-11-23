using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public float worldScrollingSpeed = 0.1f;

    public TextMeshProUGUI scoreText;

    public Button resetButton;

    float score = 0;
    int coins = 0;

    private void Awake()
    {
        if( Instance == null )
        {
            Instance = this;
        }
        else
        {
            Debug.LogError("Multiple GMs in the Scene");
        }
    }
    private void Start()
    {
        Debug.Log("Coins: " + PlayerPrefs.GetInt("Coins"));
        coins = PlayerPrefs.GetInt("Coins");
    }

    private void FixedUpdate()
    {
        score += worldScrollingSpeed;
        scoreText.text = score.ToString("0");
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        resetButton.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }
   
    public void CoinCollected()
    {
        coins++;
        PlayerPrefs.SetInt("Coins", coins);
    }
}
