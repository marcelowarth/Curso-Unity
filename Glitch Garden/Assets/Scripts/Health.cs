using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public float health;
	
	public void ReceiveDamage(float damage) {
		health -= damage;
		if(health <= 0) {
			DestroyGameObject();
		}
	}
	
	public void DestroyGameObject() {
		Destroy (gameObject);
	}
}
