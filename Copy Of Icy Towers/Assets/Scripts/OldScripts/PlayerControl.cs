using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

	[SerializeField] private GameControl gameControl;

	public float gravity = -9.8f;
	public float playerSpeed = 5f;

	public bool grounded = false;
	public Transform groundCheck;
	Vector2 groundRadius = new Vector2(0.2f,0.2f);
	public LayerMask whatIsGround;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

		grounded = Physics2D.OverlapBox (groundCheck.position, groundRadius, whatIsGround);

		// move the player left and right
		float xMovement = Input.GetAxis ("Horizontal") * playerSpeed * Time.deltaTime; 
		// keep player on screen
		float xPosition = Mathf.Clamp (xMovement, -7f, 7f); 

		float yMovement;
		if (grounded) {
			yMovement = gameControl.speed * Time.deltaTime;
		} else {
			yMovement = gravity * Time.deltaTime;
		}
			
		transform.Translate (xPosition, yMovement, 0f);
		
	}
}
