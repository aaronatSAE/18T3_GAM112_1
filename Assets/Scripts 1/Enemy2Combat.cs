using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Combat : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.gameObject.tag == "AttachedEnemy1")
        {
            gameObject.GetComponent<Enemy2Controller>().KnockOut();
        }

    }
}
