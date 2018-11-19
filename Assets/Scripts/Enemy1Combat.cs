using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Combat : MonoBehaviour {

    public GameObject self;

    public Rigidbody2D playerRB;

    private void Start()
    {

        playerRB = GameObject.FindWithTag("Player").gameObject.GetComponent<Rigidbody2D>();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            self.gameObject.GetComponent<Enemy1Controller>().KnockOut();
            playerRB.velocity = Vector2.up * 2;
        }
    }

}
