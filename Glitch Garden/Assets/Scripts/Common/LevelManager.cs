using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public float loadNextLevelAfter = 2.5f;
	
	void Start () {
		if(Application.loadedLevel == 0) {
			Invoke ("LoadNextLevel", loadNextLevelAfter);
		} else if(loadNextLevelAfter <= 0f) {
			Debug.Log("Use positive number on Load Next Level After!");
		}
	}
	
	public void LoadLevel(string name) {
		Application.LoadLevel(name);
	}
	
	public void QuitRequest() {
		Application.Quit();
	}
	
	public void LoadNextLevel() {
		Application.LoadLevel(Application.loadedLevel + 1);
	}
}
