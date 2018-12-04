using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rigidBody_BetterJumping : MonoBehaviour {

	public float gravityMultiplier = 2.5f;
	public float lowJumpMultiplier = 2.5f;

	Rigidbody2D rb;

	void Awake () {
		rb = GetComponent<Rigidbody2D> ();
	}
	

	void FixedUpdate () {
		if (rb.velocity.y < 0) {
			rb.velocity += Vector2.up * Physics.gravity.y * (gravityMultiplier - 1) * Time.deltaTime;
		} else if (rb.velocity.y > 0 && !Input.GetKey ("space")) {
			rb.velocity += Vector2.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
		}
			
	}
}
