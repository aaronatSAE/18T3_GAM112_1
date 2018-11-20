using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Pickup : MonoBehaviour {

    public bool inRange;

    public GameObject self;
    public GameObject pickupTooltip;
    public GameObject player;

    public Transform pickupArea;

    public bool isAttached;
    private Rigidbody2D rb;

    public int throwForceX;
    public int throwForceY;

    private void Start()
    {

        rb = self.gameObject.GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
        pickupArea = GameObject.FindWithTag("PickupZone").transform;

    }

    private void Update()
    {

        pickupTooltip.SetActive(inRange);
        //Debug.Log(inRange);

        if (inRange == true && Input.GetKeyDown(KeyCode.E))
        {
            Attach();
        }

        if (isAttached)
        {
            self.transform.position = pickupArea.transform.position;
        }

        if (self.gameObject.GetComponent<Enemy2Controller>().isDead == false)
        {
            Detach();
        }

    }

    private void FixedUpdate()
    {

        if (isAttached == true && Input.GetKeyDown(KeyCode.E))
        {
            Throw();
            Detach();
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (self.gameObject.GetComponent<Enemy2Controller>().isDead == true && collision.gameObject.tag == "Player")
        {
            inRange = true;
        }

        //Debug.Log("Collision");

    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        inRange = false;

    }

    public void Detach()
    {

        self.transform.parent = null;
        isAttached = false;
        player.gameObject.GetComponent<PlayerController>().hasEnemy = false;

    }

    public void Throw()
    {

        if (player.GetComponent<PlayerController>().facingRight == true)
        {
            rb.velocity = new Vector2(throwForceX, throwForceY);
            player.gameObject.GetComponent<PlayerController>().hasEnemy = false;
        }
        else if (player.GetComponent<PlayerController>().facingRight == false)
        {
            rb.velocity = new Vector2(-throwForceX, throwForceY);
            player.gameObject.GetComponent<PlayerController>().hasEnemy = false;
        }

    }

    public void Attach()
    {

        self.transform.SetParent(player.transform);
        inRange = false;
        isAttached = true;
        self.gameObject.tag = "AttachedEnemy2";
        player.gameObject.GetComponent<PlayerController>().hasEnemy = true;

    }

}
