using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Difficulty
{
    static float scoreForMaxDifficulty = 20;

    public static float GetDifficultyPercent()
    {
        float score = ScoreController.GetScore();
        return Mathf.Clamp01(score / scoreForMaxDifficulty);
    }

}
