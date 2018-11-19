using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Controller : MonoBehaviour {

    public bool isDead;
    public float deathTimer;
    public float deathTimerRemaining;

    private float moveTimer;
    public float moveTimerMax;
    public float moveSpeed;
    public bool moveDirection;

    public GameObject deadSprite;
    public Rigidbody2D rb;

    private void Start()
    {
        isDead = false;
    }

    public void Update()
    {

        deathTimerRemaining -= Time.deltaTime;

        deadSprite.SetActive(isDead);

        if (deathTimerRemaining <= 0)
        {
            isDead = false;
            gameObject.tag = "Enemy2";
        }

        moveTimer -= Time.deltaTime;

    }

    private void FixedUpdate()
    {

        if (!isDead)
        {
            Move();

            if (moveTimer <= 0)
            {
                Flip();
            }
        }

    }

    public void KnockOut()
    {

        isDead = true;
        deathTimerRemaining = deathTimer;

    }

    public void Move()
    {

        if (moveDirection)
        {
            rb.velocity = Vector2.left * moveSpeed;
        }
        else if (!moveDirection)
        {
            rb.velocity = Vector2.right * moveSpeed;
        }


    }

    public void Flip()
    {

        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
        moveTimer = moveTimerMax;
        moveDirection = !moveDirection;

    }

}
