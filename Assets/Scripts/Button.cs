using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {

    public GameObject victoryText;

    public float timer;

    private void Update()
    {

        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            victoryText.SetActive(false);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "AttachedEnemy2")
        {
            victoryText.SetActive(true);
            timer = 5;
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {

        if ((collision.gameObject.tag == "Enemy2" && timer <=0)|| (collision.gameObject.tag == "AttachedEnemy2" && timer <= 0))
        {
            victoryText.SetActive(false);
        }

    }

}
