using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour {
	public float speed = 2f;
	public float heightDiff = 2f;

	void Start(){									
		transform.Translate(0f, Random.Range(-heightDiff, heightDiff), 0f);
		var startPos = Camera.main.ViewportToWorldPoint(new Vector2(1.25f, 0.5f));
		var pos = transform.position;
		pos.x = startPos.x;
		pos.y = startPos.y + Random.Range(-2, 2);
		transform.position = pos;
	}
	void FixedUpdate() {
		transform.Translate(-speed, 0f, 0f);
		
		
		var leftBorder = Camera.main.ViewportToWorldPoint(new Vector2(-0.5f, 0f));
		if (transform.position.x < leftBorder.x){
			Destroy(gameObject);
			
		}
		

	}
}
