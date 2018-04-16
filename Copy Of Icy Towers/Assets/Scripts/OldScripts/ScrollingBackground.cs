using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour {

	[SerializeField] private GameControl gameControl;

	// Update is called once per frame
	void Update () {

		transform.Translate (0f, gameControl.speed * Time.deltaTime, 0f);

		if (transform.position.y <= -20) {
			transform.Translate (0f, 40f, 0f);
		}
		
	}
}
