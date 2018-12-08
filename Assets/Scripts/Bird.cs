using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Mathf;

public class Bird : MonoBehaviour {	
	Rigidbody2D rb2d;
	public float jumpVelocity = 15f;

	[Range(1f, 10f)]
	public float rotationVelocity = 3f;

	[Range(0.0f, 1.0f)]
	public float rotationFallTime = 0.4f;

	[Range(180f, 0.0f)]
	public float rotationTopAngle = 35f;

	[Range(0.0f,180f)]
	public float rotationBottomAngle = -70f;

	float rotation;
	float rotTime;
	
	void Awake(){
     	rb2d = GetComponent<Rigidbody2D>();
	            }   

	void Update() {
		if (Time.time - rotTime > rotationFallTime)
		rotation = Max(rotationBottomAngle,  rotation - rotationVelocity * Time.deltaTime);
		else
		rotation = Min(rotationTopAngle, rotation + rotationVelocity * Time.deltaTime); 
		   
		if (!Game.isTyping && Input.GetKeyDown(KeyCode.Space)) {
			Game.isPlaying = true;
			rb2d.simulated = true;
			rb2d.velocity = Vector2.up * jumpVelocity;
			rotation = -rotationTopAngle;
			rotTime = Time.time; }     
		else if (!Game.isPlaying) {
			rb2d.simulated = false;
			rb2d.velocity = Vector2.zero;
			var pos = transform.position;
			pos.y = Mathf.Sin(Time.time * 4f) * 0.25f;
			transform.position = pos;
			rotation = 0f;
		}	
		var rot = transform.rotation;
		rot.eulerAngles = new Vector3(0f, 0f, rotation);
		transform.rotation = rot;
	}
	
	void OnCollisionEnter2D(Collision2D col) {
		if (col.transform.tag == "Pipe") {
			Game.isPlaying = false;
			var pipes = FindObjectsOfType<Pipe>();
			for (int i = 0; i < pipes.Length; ++i)
			Destroy(pipes[i].gameObject);
			ScoreMaster.SaveScore();
			ScoreMaster.ResetScore();
		}			
	}
	
	void OnTriggerEnter2D(Collider2D col) {
		if(col.transform.tag == "Score")
		ScoreMaster.AddPoint();
	}
}




