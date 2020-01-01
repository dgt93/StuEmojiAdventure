using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject EmojiPrefab;
    public GameObject SadEmojiPrefab;
    public GameObject RubyPrefab;
    public Vector2 secondsBetweenSpawnsMinMax;
    public Vector2 secondsBetweenSadSpawnsMinMax;
    public Vector2 secondsBetweenRubySpawnsMinMax;
    float nextSpawnTime;
    float nextSadSpawnTime;
    float nextRubySpawnTime;
    public Vector2 spawnSizeMinMax;
    public Vector2 spawnSadSizeMinMax;
    public float spawnAngleMax;
    Vector2 screenHalfSizeWorldUnits;

    // Start is called before the first frame update
    void Start()
    {
        screenHalfSizeWorldUnits = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
        nextRubySpawnTime = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeSinceLevelLoad > nextSpawnTime)
        {
            float secondsBetweenSpawns = Mathf.Lerp(secondsBetweenSpawnsMinMax.y, secondsBetweenSpawnsMinMax.x, Difficulty.GetDifficultyPercent());
            nextSpawnTime = Time.timeSinceLevelLoad + secondsBetweenSpawns;

            float spawnAngle = Random.Range(-spawnAngleMax, spawnAngleMax);
            float spawnSize = Random.Range(spawnSizeMinMax.x, spawnSizeMinMax.y);
            Vector2 spawnPosition = new Vector2(Random.Range(-screenHalfSizeWorldUnits.x, screenHalfSizeWorldUnits.x), screenHalfSizeWorldUnits.y + spawnSize);
            GameObject newEmoji = (GameObject)Instantiate(EmojiPrefab, spawnPosition, Quaternion.Euler(Vector3.forward * spawnAngle));
            newEmoji.transform.localScale = Vector2.one * spawnSize;
        }

        if (Time.timeSinceLevelLoad > nextSadSpawnTime)
        {
            float secondsBetweenSadSpawns = Mathf.Lerp(secondsBetweenSadSpawnsMinMax.x, secondsBetweenSadSpawnsMinMax.y, Difficulty.GetDifficultyPercent());
            nextSadSpawnTime = Time.timeSinceLevelLoad + secondsBetweenSadSpawns;

            float spawnAngle = Random.Range(-spawnAngleMax, spawnAngleMax);
            float spawnSize = Random.Range(spawnSadSizeMinMax.x, spawnSadSizeMinMax.y);
            Vector2 spawnPosition = new Vector2(Random.Range(-screenHalfSizeWorldUnits.x, screenHalfSizeWorldUnits.x), screenHalfSizeWorldUnits.y + spawnSize);
            GameObject newEmoji = (GameObject)Instantiate(SadEmojiPrefab, spawnPosition, Quaternion.Euler(Vector3.forward * spawnAngle));
            newEmoji.transform.localScale = Vector2.one * spawnSize;
        }

        if (Time.timeSinceLevelLoad > nextRubySpawnTime)
        {
            float secondsBetweenRubySpawns = Mathf.Lerp(secondsBetweenRubySpawnsMinMax.x, secondsBetweenRubySpawnsMinMax.y, Difficulty.GetDifficultyPercent());
            nextRubySpawnTime = Time.timeSinceLevelLoad + secondsBetweenRubySpawns;
            Vector2 spawnPosition = new Vector2(Random.Range(-screenHalfSizeWorldUnits.x, screenHalfSizeWorldUnits.x), screenHalfSizeWorldUnits.y + 1);
            GameObject newEmoji = (GameObject)Instantiate(RubyPrefab, spawnPosition, Quaternion.identity);
            newEmoji.transform.localScale = Vector2.one;
        }

    }
}
