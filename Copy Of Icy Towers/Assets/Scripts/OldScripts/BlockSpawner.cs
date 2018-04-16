using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour {

	public float minSpawnDelay = 1f;
	public float maxSpawnDelay = 3f;
	public GameObject blockPrefab;

	// Use this for initialization
	void Start () {
		Spawn ();	
	}

	void Spawn () {
		Vector3 spawnPos = transform.position + new Vector3 (Random.Range (-6, 6), 0, 0);
		var go = Instantiate (blockPrefab, spawnPos, Quaternion.identity) as GameObject;
		go.AddComponent<GameControl>();
		go.AddComponent<SimplePlayerController>();

		Invoke("Spawn", Random.Range (minSpawnDelay, maxSpawnDelay));
	}
}
