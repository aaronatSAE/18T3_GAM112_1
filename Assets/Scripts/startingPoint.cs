using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startingPoint : MonoBehaviour {

    public GameObject player;

	// Use this for initialization
	void Start () {

        player = GameObject.FindWithTag("Player");
        gameObject.GetComponent<SpriteRenderer>().enabled = false;

        player.transform.position = new Vector2(this.transform.position.x, this.transform.position.y);

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
