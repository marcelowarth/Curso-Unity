using UnityEngine;
using System.Collections;

public class Shredder : MonoBehaviour {

	private LevelManager levelManager;
	
	void Start() {
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}

	void OnTriggerEnter2D (Collider2D collider) {
		if(collider.GetComponent<Attacker>()) {
			levelManager.LoadLevel("98 Lose");
		}
		Destroy(collider.gameObject);
	}
}
