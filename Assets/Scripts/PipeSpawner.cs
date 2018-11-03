using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour {
	public GameObject pipes;
	public float spawnTime = 1.5f;
	float lastTime;

	void Start() {
		lastTime = Time.time;
        
	}
	void Update(){
	if (Game.isPlaying && Time.time - lastTime > spawnTime) {
	Instantiate(pipes);
	lastTime = Time.time;
	}
	}
}
