using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;
    public float jumpHeight;
    private float moveInput;
    private Rigidbody2D rb;

    public GameObject capeSprite;

    public Transform spawnPoint;

    public bool hasCape;

    public bool facingRight = true;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private int extraJumps;
    public int maxJumps;

    private void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        hasCape = false;

    }

    private void Update()
    {

        capeSprite.SetActive(hasCape);

        if (isGrounded)
        {
            extraJumps = maxJumps;
        }

        if (Input.GetKeyDown(KeyCode.Space) && extraJumps > 0)
        {
            rb.velocity = Vector2.up * jumpHeight;
            if (hasCape == false)
            {
                extraJumps--;
            }
        }



    }

    private void FixedUpdate()
    {

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (facingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveInput < 0)
        {
            Flip();
        }

    }

    void Flip()
    {

        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;

    }

    public void HurtPlayer()
    {

        if(hasCape == true)
        {
            hasCape = false;
        }
        else if(hasCape == false)
        {
            transform.position = spawnPoint.transform.position;
        }

    }

}
