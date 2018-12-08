using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Background : MonoBehaviour
{
	

public GameObject background;
public float spawnTime = 3.0f;
float lastTime;
void Start() {
lastTime = Time.time;
}
void Update(){
	if (Game.isPlaying && Time.time - lastTime > spawnTime) {
	Instantiate(background);
	lastTime = Time.time;
	}
	}
}
