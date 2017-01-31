using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof (Rigidbody2D))]
[RequireComponent(typeof (Health))]
public class Attacker : MonoBehaviour {

	private float currentSpeed;
	private GameObject currentTarget;
	private Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
		if (!currentTarget) {
			animator.SetBool ("isAttackingBool", false);
		}
	}
	
	void OnTriggerEnter2D () {
		
	}
	
	public void SetSpeed(float speed) {
		currentSpeed = speed;
	}
	
	public void StrikeCurrentTarget(float damage) {
		if(currentTarget) {
			Health health = currentTarget.GetComponent<Health>();
			if (health) {
				health.ReceiveDamage(damage);
			}
		}
	}
	
	public void Attack(GameObject obj) {
		currentTarget = obj;
	}
}
