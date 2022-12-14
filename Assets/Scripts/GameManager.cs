using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Singleton
    public static GameManager Instance;

    //Game Settings
    public float worldScrollingSpeed = 0.1f;
    float score = 0;
    int coins = 0;

    //Powerups
    public Battery battery;
    public Magnet magnet;

    //UI
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI coinsText;
    public Button resetButton;
    SpriteRenderer player;

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
        battery.isActive = false;
        magnet.isActive = false;

        coins = PlayerPrefs.GetInt("Coins");
        coinsText.text = coins.ToString();

        player = FindObjectOfType<PlayerController>().transform.GetComponent<SpriteRenderer>();
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
        coinsText.text = coins.ToString();
    }

    public void BatteryCollected()
    {
        Debug.Log("Battery collected");
        if (battery.isActive)
        {
            CancelInvoke(nameof(CancelBattery));
            CancelBattery();
        }

        battery.isActive = true;
        player.color = Color.red;
        worldScrollingSpeed += battery.speedBoost;

        Invoke(nameof(CancelBattery), battery.immortalTime);
    }
    void CancelBattery()
    {
        battery.isActive = false;
        player.color = Color.white;
        worldScrollingSpeed -= battery.speedBoost;
    }

    public void MagnetCollected()
    {
        if (magnet.isActive)
            CancelInvoke(nameof(CancelMagnet));
        magnet.isActive = true;
        Invoke(nameof(CancelMagnet), 5);
    }
    void CancelMagnet()
    {
        magnet.isActive = false;
    }
}
