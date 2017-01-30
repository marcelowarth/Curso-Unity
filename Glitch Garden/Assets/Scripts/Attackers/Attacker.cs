using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof (Rigidbody2D))]
public class Attacker : MonoBehaviour {

	private float currentSpeed;
	private GameObject currectTarget;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
	}
	
	void OnTriggerEnter2D () {
		
	}
	
	public void SetSpeed(float speed) {
		currentSpeed = speed;
	}
	
	public void StrikeCurrentTarget(float damage) {
		
	}
	
	public void Attack(GameObject obj) {
		currectTarget = obj;
	}
}
