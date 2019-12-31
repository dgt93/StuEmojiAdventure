using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour
{

   static float score;

    // Start is called before the first frame update
    void Start()
    {
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
    }

}
