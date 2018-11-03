using UnityEngine;
using UnityEngine.UI;

public class Bird : MonoBehaviour {	
	Rigidbody2D rb2d;
	public float jumpVelocity = 15f;
	void Start() {float rotation = transform.rotation.eulerAngles.z;}
	void Awake(){
     	rb2d = GetComponent<Rigidbody2D>();
	}

	void Update() {
		    if (Input.GetKeyDown(KeyCode.Space)) {
        	Game.isPlaying = true;
			rb2d.simulated = true;
			rb2d.velocity = Vector2.up * jumpVelocity; }     
		    else if (!Game.isPlaying) {
			rb2d.simulated = false;
			rb2d.velocity = Vector2.zero;
			var pos = transform.position;
			pos.y = Mathf.Sin(Time.time * 4f) * 0.25f;
			transform.position = pos;
			 }	
	}
	void OnCollisionEnter2D(Collision2D col) {
		if (col.transform.tag == "Pipe") {
			Game.isPlaying = false;
			var pipes = FindObjectsOfType<Pipe>();
			for (int i = 0; i < pipes.Length; ++i)
			Destroy(pipes[i].gameObject);
			ScoreMaster.ResetScore();
		}			
	}
	
	void OnTriggerEnter2D(Collider2D col) {
		if(col.transform.tag == "Score")
		ScoreMaster.AddPoint();
	}
}




