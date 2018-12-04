using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasicPlayerLocomotions : MonoBehaviour {

    //Movement Variables
    public float moveSpeed; // Speed of accelleration
    public float maxSpeed; // The top Speed the player can have

    //Jumping Variables
    private bool isGrounded; // If the player is on the ground or not
    public float jumpCount; // The current remaining number of jumps a player can preform before touching the ground
    public float jumpMax; // The max number of jumps the player can preform before needing to touch the ground
    public float jumpPower; // The power of the first jump, stronger than the others
    public float doublejumpPower; // Jump power for all jumps after the first one
    public float hurtjumpPower; // How much the player bounces upon being harmed

    private bool jumpPress; // A debugging variable, makes sure that the jump button is released before the player can jump again

    //Taking Damage Variables
    public float iFrames; // Invulnerability frames currently held
    public float iFramesValue; // number of iFrames to give to the player while hurt
    public bool isImmortal; // If the player is immune to taking damage or not

    //Player Stats Variables
    private float GracePeriod;
	
	public bool facingRight = true;




    private Rigidbody2D rb2d; // The name of the Rigidbody we'll use
    private enemyVariables enemyStats; // Whatever the last enemy was, this pulls their stats
    private enemyEntity enemyAI; // The main enemy script, this is also needed when pulling an enemy's data
    public Director director; // The Level controller

	
	private Animator anims;
    private GameObject childOBJ;

    public bool isShield;
    public bool isCape;
    public bool isBoots;
    public bool isGoggles;

    public float shieldPower;
    public float baseSpeed;
    public float bootSpeed;

    // Buff stuff
    public GameObject blinkWaypoint;
    public float blinkCooldown;
    public float maxBlinkCooldown;

    // Sprites
    public GameObject forwardCape;
    public GameObject runningCape;
    public GameObject forwardGoggles;
    public GameObject runningGoggles;
    public GameObject bootsParticles;

    public bool isRunning;





    // Use this for initialization
    void Start () {

        bootsParticles.SetActive(false);
        isGoggles = false;
        shieldPower = 2;
        isShield = false;
        isGrounded = false;
        moveSpeed = 10.0f;
        maxSpeed = 2.0f;
        jumpMax = 2.0f;
        jumpCount = jumpMax;
        jumpPower = 4.5f;
        doublejumpPower = 4.0f;
        hurtjumpPower = 1.5f;
        iFrames = 0;
        iFramesValue = 30;
        isImmortal = false;
        jumpPress = false;
        GracePeriod = 2;
		
		anims =  this.gameObject.transform.GetChild(0).gameObject.GetComponent<Animator>();
        childOBJ = this.gameObject.transform.GetChild(1).gameObject;
        


        rb2d = gameObject.GetComponent<Rigidbody2D>();


		
	}

	
	// Update is called once per frame
	void Update () {

        bootsParticles.SetActive(isBoots);

        if(isRunning == true && isGoggles == true)
        {
            runningGoggles.SetActive(true);
            forwardGoggles.SetActive(false);
            forwardCape.SetActive(false);
            //runningCape.SetActive(false);
        }

        if (isRunning == false && isGoggles == true)
        {
            runningGoggles.SetActive(false);
            forwardGoggles.SetActive(true);
            //forwardCape.SetActive(false);
            runningCape.SetActive(false);
        }

        if (isRunning == false && isCape == true)
        {
            runningGoggles.SetActive(false);
            //forwardGoggles.SetActive(false);
            forwardCape.SetActive(true);
            runningCape.SetActive(false);
        }

        if (isRunning == true && isCape == true)
        {
            //runningGoggles.SetActive(false);
            forwardGoggles.SetActive(false);
            forwardCape.SetActive(false);
            runningCape.SetActive(true);
        }



        blinkCooldown -= Time.deltaTime;
        blinkWaypoint.gameObject.GetComponent<SpriteRenderer>().enabled = isGoggles; 


        if (isBoots == true)
        {
            moveSpeed = bootSpeed;
        }

        else
        {
            moveSpeed = baseSpeed;
        }

        if(shieldPower > 0)
        {
            isShield = true;
            childOBJ.SetActive(true);
        }

        else
        {
            isShield = false;
            childOBJ.SetActive(false);
        }


		GracePeriod -= 1;
        //Checks if the player still has iFrames, and if they should be immortal or not
        checkImmortality();
		
        if (isGrounded == true)
        {
            //Resets their number of allowed jumps
            ReloadJumps();
            //other features such as setting the animation handler to preform a landing animation, or cancelling some of the airborne only abilities that may or may not exist.
        } else {
			
		}

        //Gets input values from Unity's built in engine and moves horizontally based on this
        float h = Input.GetAxis("Horizontal");
        float hMove = h * moveSpeed;
        rb2d.velocity = new Vector2(hMove, rb2d.velocity.y);
		
		if (h != 0){
			anims.SetBool("isMoving", true);
            isRunning = true;
		} else {
			anims.SetBool("isMoving", false);
            isRunning = false;
		}
		
		        if (facingRight == false && h > 0)
        {
            Flip();
        }
        else if (facingRight == true && h < 0)
        {
            Flip();
        }

        //Prevents the player from moving TOO fast
        if (rb2d.velocity.x > maxSpeed)
        {
            rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y);
        }
        if (rb2d.velocity.x < -maxSpeed)
        {
            rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y);
        }


        //KeyPress Handler


        if (Input.GetKeyDown("space"))
        {
            if (jumpPress == false)
            {
                doJump();
                jumpPress = true;
				anims.SetBool("isJumping", true);
				GracePeriod = 2;
            }
        }

        if (Input.GetKeyDown("e"))
        {
           // director.LoseLevel();
        }

        //if (Input.GetKeyDown("q"))
        //{
        //    director.CompleteLevel();
        //}

        if (Input.GetKeyUp("space"))
        {
            jumpPress = false;

        }

        // Goggles
        if (isGoggles && blinkCooldown <= 0 && Input.GetKeyDown(KeyCode.Q))
        {
            transform.position = blinkWaypoint.transform.position;
            blinkCooldown = maxBlinkCooldown;
            blinkWaypoint.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }

        if (isGoggles && blinkCooldown <= 0)
        {
            blinkWaypoint.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }



    }

    //Checks if the player collided with anything that has the "Platform" tag, and if the player is above it, to reset the jump counter
    private void OnCollisionStay2D(Collision2D collision)

 
    {
  
        if (collision.gameObject.tag == "Platform" || collision.gameObject.tag == "Rock"  )
        {
            if(transform.position.y > collision.transform.position.y)
            {
		if (GracePeriod <= 0){
			    anims.SetBool("isJumping", false);
		}
                ReloadJumps();
            }
        } 
		


        if (collision.gameObject.tag == "Hazard")
        {
            enemyStats = collision.gameObject.GetComponent<enemyVariables>();
            takeDamage();

            if (transform.position.y > collision.transform.position.y)
            {
                 ReloadJumps();

            }
        }


        if (collision.gameObject.tag == "Shield")
        {
            if (isShield == false)
            {
                Destroy(collision.gameObject);
                GetShield();
            }
        }

        if (collision.gameObject.tag == "Boots")
        {
            if (isBoots == false)
            {
                Destroy(collision.gameObject);
                isBoots = true;
               // GetBoots();
            }
        }

        if (collision.gameObject.tag == "Goggles")
        {
            if (isGoggles == false)
            {
                Destroy(collision.gameObject);
                isGoggles = true; 
                //GetGoggles();
            }
        }

        if (collision.gameObject.tag == "Cape")
        {
            if (isCape == false)
            {
                Destroy(collision.gameObject);
                isCape = true;
                //GetCape();
            }
        }


        if (collision.gameObject.tag == "Hostile")
        {
            //Pulls the information of the enemy collided with
            enemyStats = collision.gameObject.GetComponent<enemyVariables>();
            enemyAI = collision.gameObject.GetComponent<enemyEntity>();

            //Grabs all corners of the collision and then Draws a Line to find where the impact came from

            foreach (ContactPoint2D point in collision.contacts)
            {
                //If the player landed on top the enemy with a 0.1 margin for comfort
                if (point.normal.y >= 0.9f)
                {
                    //Reload jumps but check if the enemy is spiked -- If they are spiked, the player gets damaged, if not, the player damages them, and receives a bounce
                    ReloadJumps();
                    if (enemyAI.isSpiked == true)
                    {
                        iFrames += 1;
                        takeDamage();
                    }
                    else
                    {
									if (enemyAI.isWounded == true){
										enemyAI.die();
									}
									else{
                        enemyAI.getHurt();
									}
                        rb2d.velocity = new Vector2(rb2d.velocity.x, doublejumpPower);

                    }
                }
                else
                {
					if (enemyAI.isWounded == false){
                    iFrames += 1;
                    takeDamage();
					}
                }
            }
        }
    }






        //Basic function that handles jumps
        void doJump()
    {
        // If the player is still allowed to jump, check if it's the first jump, or any jumps after, and lower the jump count by one.
        if (jumpCount > 0.0f)
        {
            jumpCount -= 1.0f;

            if (jumpCount == jumpMax)
            {
                rb2d.velocity = new Vector2(rb2d.velocity.x, jumpPower);
            } else
            {
                rb2d.velocity = new Vector2(rb2d.velocity.x, doublejumpPower);
            }
 
        }

    }




    // Removes iFrames 1 by 1 until the player has none, while the player has iframes, they are immune to damage
    void checkImmortality()

    {
        if (iFrames > 0)
        {
            iFrames -= 1;
            isImmortal = true;
            Physics2D.IgnoreLayerCollision(8, 10, true);
        }
        else
        {
            iFrames = 0;
            isImmortal = false;
            Physics2D.IgnoreLayerCollision(8, 10, false);
        }

        

    }

    // Refills allowed jump count
    void ReloadJumps()
    {
        if (jumpPress == false)
        {
            jumpCount = jumpMax;
        }

    }

    void takeDamage()
    {
        

        if (isImmortal == false)
        {
            if (isShield == true)
            {

                shieldPower -= 1;
                rb2d.velocity = new Vector2(rb2d.velocity.x, hurtjumpPower);
                anims.SetBool("isJumping", true);
                GracePeriod = 2;
                iFrames += iFramesValue;


            }

            else if (isShield == false && (isCape == true || isBoots == true || isGoggles == true))
            {
                isGoggles = false;
                isCape = false;
                isBoots = false;
                forwardGoggles.SetActive(false);
                forwardCape.SetActive(false);
                runningCape.SetActive(false);
                runningGoggles.SetActive(false);
            }


            else
            {
                director.LoseLevel();
                
                
            }

        }
    }
	
	    void Flip()
    {

        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;

    }



    void GetShield()
    {
        shieldPower = 2;
    }
}
