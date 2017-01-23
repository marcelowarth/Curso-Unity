using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
	
	public float velocity = 5f;
	public GameObject enemyPrefab;
	public float width = 10f;
	public float height = 5f;
	
	private bool right = false;
	private float xMin, xMax;

	// Use this for initialization
	void Start () {
		Spawn ();
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
			Spawn ();
		}
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
