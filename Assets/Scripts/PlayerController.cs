using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;
    public float baseSpeed;
    public float bootSpeed;
    public float jumpHeight;
    private float moveInput;
    private Rigidbody2D rb;

    public GameObject blinkWaypoint;
    public float blinkCooldown;
    public float maxBlinkCooldown;

    public GameObject capeSprite;
    public GameObject bootSprite;
    public GameObject goggleSprite;

    public Transform spawnPoint;

    public bool hasCape;
    public bool hasBoots;
    public bool hasGoggles;
    public bool hasEnemy = false;

    public bool facingRight = true;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    public Animator animator;
    public GameObject moveAnim;
    public GameObject idleAnim;
    public GameObject carryAnim;

    private int extraJumps;
    public int maxJumps;

    private void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        hasCape = false;

    }

    private void Update()
    {

        capeSprite.gameObject.GetComponent<SpriteRenderer>().enabled = hasCape;
        bootSprite.gameObject.GetComponent<SpriteRenderer>().enabled = hasBoots;
        goggleSprite.gameObject.GetComponent<SpriteRenderer>().enabled = hasGoggles;

        blinkCooldown -= Time.deltaTime;

        if (isGrounded && !hasCape)
        {
            extraJumps = maxJumps;
        }
        if(isGrounded && hasCape)
        {
            extraJumps = maxJumps + 2;
        }

        if (Input.GetKeyDown(KeyCode.Space) && extraJumps > 0)
        {
            rb.velocity = Vector2.up * jumpHeight;
            extraJumps--;

        }

        if (hasBoots)
        {
            speed = bootSpeed;
        }
        else
        {
            speed = baseSpeed;
        }

        if (hasGoggles && blinkCooldown <= 0 && Input.GetKeyDown(KeyCode.Q))
        {
            transform.position = blinkWaypoint.transform.position;
            blinkCooldown = maxBlinkCooldown;
            blinkWaypoint.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }

        if (hasGoggles && blinkCooldown <= 0)
        {
            blinkWaypoint.gameObject.GetComponent<SpriteRenderer>().enabled = true;
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

        if (moveInput != 0)
        {
            animator.SetBool("isMoving", true);
            moveAnim.SetActive(true);
            idleAnim.SetActive(false);
            carryAnim.SetActive(false);
        }
        else if (moveInput == 0)
        {
            animator.SetBool("isMoving", false);
            moveAnim.SetActive(false);
            carryAnim.SetActive(false);
            idleAnim.SetActive(true);
        }
        else if (moveInput != 0 && hasEnemy == true)
        {
            carryAnim.SetActive(true);
            idleAnim.SetActive(false);
            moveAnim.SetActive(false);
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
