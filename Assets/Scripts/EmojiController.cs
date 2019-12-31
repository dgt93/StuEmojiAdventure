using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmojiController : MonoBehaviour
{

    public Vector2 speedMinMax;
    float speed;
    float visibleHeightThreshold;
    public Sprite[] sprites;
    private SpriteRenderer spriteR;


    // Start is called before the first frame update
    void Start()
    {
        spriteR = GetComponent<SpriteRenderer>();
        spriteR.sprite = sprites[Random.Range(0, sprites.Length)];

        speed = Mathf.Lerp(speedMinMax.x, speedMinMax.y, Difficulty.GetDifficultyPercent());

        visibleHeightThreshold = -Camera.main.orthographicSize - transform.localScale.y;
     
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if(transform.position.y < visibleHeightThreshold)
        {
            Destroy(gameObject);
        }

    }
}
