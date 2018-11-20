using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishDoor : MonoBehaviour {

    public bool hasEnoughStars = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player" && hasEnoughStars == true)
        {
            Debug.Log("You Win!");
        }

    }

}
