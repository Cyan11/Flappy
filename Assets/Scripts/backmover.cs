using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backmover : MonoBehaviour {
public float speed = 0.06f;
void Update() {
	if (Game.isPlaying) {
		transform.Translate(-speed,0,0);

	}
    var leftBorder = Camera.main.ViewportToWorldPoint(new Vector2(-0.9f, 0f));
		if (transform.position.x < leftBorder.x){
			Destroy(gameObject);
		}


}
}
