using UnityEngine;
using System.Collections;

public class SpawnAttackers : MonoBehaviour {

	private GameObject parent;
	
	public GameObject[] attackerPrefabArray;
	
	void Start() {
		parent = GameObject.Find ("Attackers");
		if(!parent) {
			parent = new GameObject("Attackers");
		}
	}
	
	void Update() {
		foreach (GameObject thisAttacker in attackerPrefabArray) {
			if(IsTimeToSpawn(thisAttacker)) {
				Spawn(thisAttacker);
			}
		}
	}

	void Spawn(GameObject attacker) {
		GameObject newAtk = Instantiate(attacker) as GameObject;
		newAtk.transform.parent = transform;
		newAtk.transform.position = transform.position;
	}
	
	bool IsTimeToSpawn(GameObject attackerGameObject) {
		Attacker attacker = attackerGameObject.GetComponent<Attacker>();
		float meanSpawnDelay = attacker.seenEverySeconds;
		float spawnsPerSecond = 1 / meanSpawnDelay;
		
		if(Time.deltaTime > meanSpawnDelay) {
			Debug.LogWarning("Spawn capped by frame rate");
		} 
		
		float threshold = spawnsPerSecond * Time.deltaTime / 5;
		
		return Random.value < threshold;
	}
}
