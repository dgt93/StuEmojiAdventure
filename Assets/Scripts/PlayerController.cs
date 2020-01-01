using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float defaultSpeed = 15;
    private float speed = 15;
    float screenHalfWidthInWorldUnits;
    public event System.Action OnPlayerDeath;
    public event System.Action OnPlayerScore;
    public Sprite normal;
    public Sprite Lightning;
    public float LightningScale;
    private SpriteRenderer spriteR;

    // Start is called before the first frame update
    void Start()
    {
        spriteR = GetComponent<SpriteRenderer>();
        spriteR.sprite = normal;
        transform.localScale = new Vector3(0.1f, 0.1f);
        speed = defaultSpeed;
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

        if (ScoreController.GetScore() > 9)
        {
            spriteR = GetComponent<SpriteRenderer>();
            spriteR.sprite = Lightning;
            transform.localScale = new Vector3(LightningScale, LightningScale);
            speed = 25;
            float halfPlayerWidth = transform.localScale.x / 2f;
            screenHalfWidthInWorldUnits = Camera.main.aspect * Camera.main.orthographicSize + halfPlayerWidth;
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

        if (triggerCollider.tag == "Ruby")
        {
            OnPlayerScore?.Invoke();
            OnPlayerScore?.Invoke();
            OnPlayerScore?.Invoke();
            OnPlayerScore?.Invoke();
            OnPlayerScore?.Invoke();
        }

    }
}
