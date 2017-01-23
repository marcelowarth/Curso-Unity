using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
	
	public float velocity = 5f;
	public GameObject enemyPrefab;
	public float width = 10f;
	public float height = 5f;
	public float spawnDelay = 0.5f;
	
	private bool right = false;
	private float xMin, xMax;

	// Use this for initialization
	void Start () {
		SpawnUntilFull ();
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftMost = Camera.main.ViewportToWorldPoint(new Vector3(0,0,distance));
		Vector3 rightMost = Camera.main.ViewportToWorldPoint(new Vector3(1,0,distance));
		xMin = leftMost.x;
		xMax = rightMost.x;
	}
	
	void Spawn () {
		foreach (Transform child in transform) {
			GameObject enemy = Instantiate(enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;
			enemy.transform.parent = child;
		}
	}
	
	void SpawnUntilFull () {
		Transform freePosition = NextFreePosition();
		if(freePosition) {
			GameObject enemy = Instantiate(enemyPrefab, freePosition.position, Quaternion.identity) as GameObject;
			enemy.transform.parent = freePosition;
		}
		if (NextFreePosition()) {
			Invoke ("SpawnUntilFull", spawnDelay);
		}
	}
	
	void OnDrawGizmos() {
		Gizmos.DrawWireCube(transform.position, new Vector3(width, height));
	}
	
	// Update is called once per frame
	void Update () {
		if(right) {
			transform.position += Vector3.right * velocity * Time.deltaTime;
		} else {
			transform.position += Vector3.left * velocity * Time.deltaTime;
		}
		VerifyEdge();
		
		// Restrict to game space
		float newX = Mathf.Clamp(transform.position.x, xMin, xMax);
		transform.position = new Vector3(newX, transform.position.y, transform.position.z);
		
		if (AllMembersDead()) {
			SpawnUntilFull ();
		}
	}
	
	Transform NextFreePosition() {
		foreach(Transform childPositionGameObject in transform) {
			if (childPositionGameObject.childCount == 0) {
				return childPositionGameObject;
			}
		}
		return null;
	}
	
	bool AllMembersDead () {
		foreach(Transform childPositionGameObject in transform) {
			if (childPositionGameObject.childCount > 0) {
				return false;
			}
		}
		return true;
	}
	
	void VerifyEdge () {
		float rightEdge = transform.position.x + (0.5f * width);
		float leftEdge = transform.position.x - (0.5f * width);
		if (leftEdge < xMin) {
			right = true;
		} else if (rightEdge > xMax) {
			right = false;
		}
	}
}
