using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Controller : MonoBehaviour {

    public bool isDead;
    public float deathTimer;
    public float deathTimerRemaining;

    public GameObject deadSprite;

    private void Start()
    {
        isDead = false;
    }

    public void Update()
    {

        deathTimerRemaining -= Time.deltaTime;

        deadSprite.SetActive(isDead);

        if(deathTimerRemaining <= 0)
        {
            isDead = false;
            gameObject.tag = "Enemy1";
        }

    }

    public void KnockOut()
    {

        isDead = true;
        deathTimerRemaining = deathTimer;

    }

}
