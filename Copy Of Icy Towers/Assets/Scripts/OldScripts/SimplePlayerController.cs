using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePlayerController : PhysicsObject {

	public float maxSpeed = 7f;
	public float jumpTakeOffSpeed = 7f;
	public float minJump = 10f;

	// Update is called once per frame
	protected override void ComputeVelocity() {
		Vector2 move = Vector2.zero;

		move.x = Input.GetAxis ("Horizontal");
		if (Input.GetButtonDown ("Jump") && grounded) {
			velocity.y = Mathf.Abs(velocity.x)*jumpTakeOffSpeed;
			if (velocity.y < minJump) {
				velocity.y = minJump;
			}
			Debug.Log (velocity.y);
		}

		targetVelocity = move * maxSpeed;
	}

	public float yVelocity { 
		get { return velocity.y; }
	}
}
