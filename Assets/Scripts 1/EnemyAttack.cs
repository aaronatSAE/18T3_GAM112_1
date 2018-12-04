using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {

    public GameObject self;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.gameObject.tag == "Player" && self.gameObject.GetComponent<Enemy1Controller>().isDead == false)
        {
            collision.gameObject.GetComponent<PlayerController>().HurtPlayer();
        }

    }

}
