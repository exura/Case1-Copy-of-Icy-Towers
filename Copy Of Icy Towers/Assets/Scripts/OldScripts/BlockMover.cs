using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMover : MonoBehaviour {

	private SimplePlayerController player;
	private GameControl gameControl;
	private BoxCollider2D collider;

	// Use this for initialization
	void Start () {
		collider = GetComponent<BoxCollider2D> ();
		player = FindObjectOfType<SimplePlayerController> ();
		gameControl = FindObjectOfType<GameControl> ();
	}

	void Update() {
		transform.Translate (0f, gameControl.speed * Time.deltaTime, 0f);
		if (player.yVelocity > 0) {
			collider.enabled = false;
		} else if (player.yVelocity <= 0) {
			collider.enabled = true;
		}
	}

}
