using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    public GameObject gameOverScreen;
    public Text scoreUI;

    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<PlayerController>().OnPlayerDeath += OnGameOver;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(0);
        }
    }

    void OnGameOver()
    {
        gameOverScreen.SetActive(true);
        scoreUI.text = ScoreController.GetScore().ToString();
    }

}
