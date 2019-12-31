﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 15;
    float screenHalfWidthInWorldUnits;
    public event System.Action OnPlayerDeath;
    public event System.Action OnPlayerScore;
    public Sprite[] sprites;
    private SpriteRenderer spriteR;

    // Start is called before the first frame update
    void Start()
    {
        float halfPlayerWidth = transform.localScale.x / 2f;
        screenHalfWidthInWorldUnits = Camera.main.aspect * Camera.main.orthographicSize + halfPlayerWidth;
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float velocity = inputX * speed;
        transform.Translate(Vector2.right * velocity * Time.deltaTime);

        if (transform.position.x < -screenHalfWidthInWorldUnits)
        {
            transform.position = new Vector2(screenHalfWidthInWorldUnits, transform.position.y);
        }

        if (transform.position.x > screenHalfWidthInWorldUnits)
        {
            transform.position = new Vector2(-screenHalfWidthInWorldUnits, transform.position.y);
        }

        if (ScoreController.GetScore() > 10)
        {

        }

    }

    private void OnTriggerEnter2D(Collider2D triggerCollider)
    {
        if(triggerCollider.tag == "Not Sad Emoji")
        {
            OnPlayerDeath?.Invoke();
            Destroy(gameObject);
        }

        if(triggerCollider.tag == "Sad Emoji")
        {
            OnPlayerScore?.Invoke();
        }

    }

}
