using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    static float score = 0;
    public Text scoreUI;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        FindObjectOfType<PlayerController>().OnPlayerScore += UpdateScore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static float GetScore()
    {
        return score;
    }

    void UpdateScore()
    {
        score = score + 1;
        scoreUI.text = "Score: " + score.ToString();
    }

}
