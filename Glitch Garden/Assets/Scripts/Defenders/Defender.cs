using UnityEngine;
using System.Collections;

[RequireComponent(typeof (Health))]
public class Defender : MonoBehaviour {

	private Health health;

	// Use this for initialization
	void Start () {
		health = GetComponent<Health>();
	}
	
	// Update is called once per frame
	void Update () {
		if(health.health <= 0) {
			//Destroy();
		}
	}
	
	void OnTriggerEnter2D () {
		
	}
}
