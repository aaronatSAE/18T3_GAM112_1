using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyEntity : MonoBehaviour {

    //Raw Stats
    public float moveSpeed;
    public float hpCurrent;
    public float hpMax;

    //AI Behaviors
    public bool canWalkOffEdge; //If they can walk off ledges
    public bool TargetPlayer; // If they always face the player
    public bool isPatrolling; // Moves on their own without provocation
    public bool canFly; // Ability to fly
    public bool isSpiked; // If the player is allowed to jump on top of this enemy

    public bool isWallRider; // If the enemy walks around walls
    public float wallRiderDirection; // Float used to know which direction the WallRider is moving in

    //Required for all AIS
    private RaycastHit2D isGrounded;
    private RaycastHit2D isGrounded2;
    private RaycastHit2D isGrounded3;
    private bool firstGrounded;
    float myWidth;
    public LayerMask enemyMask;
    private Rigidbody2D rb2d; // The name of the Rigidbody we'll use
    private Transform myTransform;
    private GameObject player;


    // Use this for initialization
    void Start () {

        hpCurrent = hpMax;
        rb2d = this.GetComponent<Rigidbody2D>();
        myWidth = this.GetComponent<SpriteRenderer>().bounds.extents.x; // Gets the width of the Enemy for any Sprite
        Physics2D.IgnoreLayerCollision(8, 8); // Ignores collisions with other Enemies
        myTransform = this.transform;
        firstGrounded = false; // A debugging variable that fixes any oddities with enemies being airborne before hitting the ground for the first time
        player = GameObject.FindWithTag("Player"); // Getting the player Object

        //Variable assignment for WallRider specific entities
        if (isWallRider == true)
        {
                wallRiderDirection = 1;
        }
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        if(TargetPlayer == true)
        {
            facePlayer();
        }

        //Checks if ground is in front of them
        if (isWallRider == false)
        {
            Vector2 lineCastPos = myTransform.position - myTransform.right * myWidth;
            if (isGrounded = Physics2D.Linecast(lineCastPos, lineCastPos + Vector2.down, enemyMask))
            {
                if (isGrounded.distance <= 0.1f)
                {
                    firstGrounded = true;
                }
            }
            if (!isGrounded || isGrounded.distance >= 0.18f)
            {
                if (firstGrounded == true)
                {
                    // If there is no ground, turn around if unable to fly or walk off edges
                    if (canWalkOffEdge == false && canFly == false)
                    {
                        Vector3 CurrRot = myTransform.eulerAngles; // Gets current Rotations
                                                                   // IF the AI doesn't target the player, change rotation
                        if (TargetPlayer == false)
                        {
                                CurrRot.y += 180; // Flips Rotation
                        }
                        myTransform.eulerAngles = CurrRot; // Applies New Rotations
                        moveSpeed = -moveSpeed; // Reverses moveSpeed in order to move the opposite direction
                    }
                }

            }
        }

        //WallRider Platform Check Scripts
        if (isWallRider == true)
        {
            if (wallRiderDirection == 1)
            {
                Vector2 lineCastPos = myTransform.position - myTransform.right * myWidth;
                isGrounded = Physics2D.Linecast(lineCastPos, lineCastPos + new Vector2(0, -0.3f), enemyMask);
                lineCastPos = myTransform.position + myTransform.right * myWidth;
                isGrounded2 = Physics2D.Linecast(lineCastPos, lineCastPos + new Vector2(0, -0.3f), enemyMask);
                lineCastPos = myTransform.position;
                isGrounded3 = Physics2D.Linecast(lineCastPos, lineCastPos + new Vector2(0, -0.3f), enemyMask);
                if (!isGrounded && !isGrounded2 && !isGrounded3)
                {
                    WallRiderRotation();
                }
                }
                if (wallRiderDirection == 2)
            {
                Vector2 lineCastPos = myTransform.position - myTransform.right * myWidth;
                isGrounded = Physics2D.Linecast(lineCastPos, lineCastPos + new Vector2(0.3f, 0), enemyMask);
                lineCastPos = myTransform.position + myTransform.right * myWidth;
                isGrounded2 = Physics2D.Linecast(lineCastPos, lineCastPos + new Vector2(0.3f, 0), enemyMask);
                lineCastPos = myTransform.position;
                isGrounded3 = Physics2D.Linecast(lineCastPos, lineCastPos + new Vector2(0.3f, 0), enemyMask);
                if (!isGrounded && !isGrounded2 && !isGrounded3)
                {
                    WallRiderRotation();
                }


            }
            if (wallRiderDirection == 3)
            {
                Vector2 lineCastPos = myTransform.position - myTransform.right * myWidth;
                isGrounded = Physics2D.Linecast(lineCastPos, lineCastPos + new Vector2(0, 0.3f), enemyMask);
                lineCastPos = myTransform.position + myTransform.right * myWidth;
                isGrounded2 = Physics2D.Linecast(lineCastPos, lineCastPos + new Vector2(0, 0.3f), enemyMask);
                lineCastPos = myTransform.position;
                isGrounded3 = Physics2D.Linecast(lineCastPos, lineCastPos + new Vector2(0, 0.3f), enemyMask);
                if (!isGrounded && !isGrounded2 && !isGrounded3)
                    {
                               WallRiderRotation();
                            }
                    
                    
            }
            if (wallRiderDirection == 4)
            {
                Vector2 lineCastPos = myTransform.position - myTransform.right * myWidth;
                isGrounded = Physics2D.Linecast(lineCastPos, lineCastPos + new Vector2(-0.3f, 0), enemyMask);
                lineCastPos = myTransform.position + myTransform.right * myWidth;
                isGrounded2 = Physics2D.Linecast(lineCastPos, lineCastPos + new Vector2(-0.3f, 0), enemyMask);
                lineCastPos = myTransform.position;
                isGrounded3 = Physics2D.Linecast(lineCastPos, lineCastPos + new Vector2(-0.3f, 0), enemyMask);
                if (!isGrounded && !isGrounded2 && !isGrounded3)
                {
                    WallRiderRotation();
                }


            }

        }


            //Move Forward Constantly if isPatrolling is enabled
            if (isPatrolling == true && isWallRider == false)
        {
            Vector2 myVel = rb2d.velocity;
            myVel.x = -moveSpeed;
            rb2d.velocity = myVel;
        }

        //WallRider Movements
        if(isWallRider == true)
        {
            Vector2 myVel = rb2d.velocity;
            if (wallRiderDirection == 1)
            {
                myVel.x = -moveSpeed;
                rb2d.gravityScale = 1;
            }
            if (wallRiderDirection == 2)
            {
                myVel.y = -moveSpeed;
                rb2d.gravityScale = 0;
            }
            if (wallRiderDirection == 3)
            {
                myVel.x = moveSpeed;
                rb2d.gravityScale = 0;
            }
            if (wallRiderDirection == 4)
            {
                myVel.y = +moveSpeed;
                rb2d.gravityScale = 0;
            }
            rb2d.velocity = myVel;

        }
		
	}

    public void getHurt()
    {
        // If enemy is instructed to take damage
        Destroy(gameObject);
    }

    //Constantly faces the player
    private void facePlayer()
    {
        Vector3 CurrRot = myTransform.eulerAngles;
        if (player.transform.position.x > this.transform.position.x)

        {
            CurrRot.y = 180;
        }else
        {
            CurrRot.y = 0;
        }


        myTransform.eulerAngles = CurrRot;

    }

    private void WallRiderRotation()
    {
        Vector3 CurrRot = myTransform.eulerAngles;
        CurrRot.z += 90; // Flips Rotation
        Vector2 myVel = rb2d.velocity;
        myVel.x = 0;
        myVel.y = 0;
        rb2d.velocity = myVel;
        wallRiderDirection += 1;
        if (wallRiderDirection == 2)
        {
            this.transform.position = new Vector2(this.transform.position.x + 0.1f, this.transform.position.y - 0.1f);
        }
        if (wallRiderDirection == 3)
        {
            this.transform.position = new Vector2(this.transform.position.x + 0.1f, this.transform.position.y + 0.1f);
        }
        if (wallRiderDirection == 4)
        {
            this.transform.position = new Vector2(this.transform.position.x - 0.1f, this.transform.position.y + 0.1f);
        }
        if (wallRiderDirection >= 5)
        {
            this.transform.position = new Vector2(this.transform.position.x - 0.3f, this.transform.position.y - 0.1f);
            wallRiderDirection = 1;
        }
        myTransform.eulerAngles = CurrRot; // Applies New Rotations


    }
}
