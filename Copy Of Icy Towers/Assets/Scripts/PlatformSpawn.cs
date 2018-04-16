using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawn : MonoBehaviour {

	private GameObject[] movingPlatforms;
	private int length = 10;
	public GameObject platformPrefab;
	public float platformDistance = 2f;
	/*Vector3[] waypoints = new Vector3[2];*/
	//shit.Length = 1;
	Vector3 spawnPos;
	Vector3 targetPos;

	// Use this for initialization
	void Start () {
		movingPlatforms = new GameObject[length];

		spawnPos = transform.position;
		targetPos = spawnPos + Vector3.up * -22f;

		/*waypoints[0]= spawnPos;
		waypoints[1]= targetPos;*/

		for (int i = 0; i < movingPlatforms.Length; i++) {
			StartSpawn (i);
		}
	}

	void Update() {
		for (int i = 0; i < movingPlatforms.Length; i++) {
			if (movingPlatforms [i].transform.position.y < -10) {
				Respawn (i);
			}
		}

	}

	void StartSpawn(int i) {
		Vector3 randomPos = RandomPos ();
		/*waypoints [0] = spawnPos - Vector3.up * i * platformDistance + randomPos;
		waypoints [1] = targetPos - Vector3.up * i * platformDistance + randomPos;
		movingPlatforms [i] = Instantiate (platformPrefab, waypoints [0], Quaternion.identity) as GameObject;
		Debug.Log ("Position of platform: " + (waypoints[0]) + " Target of platform: " + (waypoints[1]));
		movingPlatforms [i].GetComponent<PlatformController>().LocalWayPoints(waypoints);*/
		movingPlatforms [i] = Instantiate (platformPrefab, spawnPos - Vector3.up * i * platformDistance + randomPos, Quaternion.identity) as GameObject;
		movingPlatforms [i].transform.localScale = new Vector3(Random.Range(1f,3f),0.2f,1f);
	}

	void Respawn(int i) {
		Destroy(movingPlatforms [i].gameObject);
		Vector3 randomPos = RandomPos ();
		/*waypoints [0] = Vector3.zero + randomPos;
		waypoints [1] = Vector3.up*-22f + randomPos;
		movingPlatforms [i] = Instantiate (platformPrefab, waypoints [0], Quaternion.identity) as GameObject;
		movingPlatforms [i].GetComponent<PlatformController>().LocalWayPoints(waypoints);*/
		movingPlatforms [i] = Instantiate (platformPrefab, spawnPos + randomPos, Quaternion.identity) as GameObject;
		movingPlatforms [i].transform.localScale = new Vector3(Random.Range(1f,3f),0.2f,1f);
	}

	Vector3 RandomPos() {
		return Vector3.right * Random.Range (-4f, 4f);
	}
}
