using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

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
		highscore = PlayerPrefs.GetInt("Highscore");
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
	
	public static void SaveScore() {
		var highscores = new List<int>(10);
		var names = new List<string>(10);

		for(int i = 0; i<= 10; ++i){
			highscores[i] = PlayerPrefs.GetInt("highscore" + i , 0 );
			names[i]      = PlayerPrefs.GetString("name" + i, "WAH");
		 }
		 for(int i = 0; i < 10; ++i) {
		if(score > highscore[i]) {
			//Mostrar Lista; Pegar nome. TBD
			string name = "TBD";

		highscores.Insert(score, i);
		names.Insert(name, i);
		for(int i = 0; i < 10; ++i){
			PlayerPrefs.SetInt("highscore" + i, highscores[i]);
			PlayerPrefs.SetString("name" + i, names[i]);
		}
		break;		
		}
	
		 }

	}
}
