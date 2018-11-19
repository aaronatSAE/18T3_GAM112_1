using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Attack : MonoBehaviour {

    public GameObject self;

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player" && self.gameObject.GetComponent<Enemy2Controller>().isDead == false)
        {
            collision.gameObject.GetComponent<PlayerController>().HurtPlayer();
        }

    }
}
