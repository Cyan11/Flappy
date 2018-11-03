using UnityEngine;

public class Game : MonoBehaviour {
    public static Game instance;
	public static Game Get() {
		return instance;
}
public static bool isPlaying = false;
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




 }



