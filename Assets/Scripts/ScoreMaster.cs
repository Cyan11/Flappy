using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreMaster : MonoBehaviour {
	public static ScoreMaster instance;
	public static ScoreMaster Get() {
		return instance;
	}
	public static int score = 0;
	public Text scoreText;
	public static int highscore = 0;

	void Awake() {
		if (instance != null) {
			DestroyImmediate(this);
			Debug.LogWarning(
				"There should be only one instance of " +
				"ScoreSystem. Deleting this instance..."
			);
			return;
		}
		instance = this;
	}

	void Start() {
		ResetScore();
	}

	public static void AddPoint() {
		++score;
		highscore = Mathf.Max(score, highscore);
		Get().scoreText.text = "Score: " + score + "                       HighScore: " + highscore; 
	}
	
	public int GetScore() {
		return score;
	}

	public static void ResetScore() {
		score = 0;
		Get().scoreText.text = "Score: 0                       HighScore: " + highscore;
	}
}
