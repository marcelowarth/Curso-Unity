using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {

	public float health = 150f;
	public GameObject projectile;
	public float projectileSpeed = 5f;
	public float shotsPerSecond = 0.5f;

	void OnTriggerEnter2D(Collider2D coll) {
		Projectile missile = coll.gameObject.GetComponent<Projectile>();
		if (missile) {
			health -= missile.GetDamage();
			missile.Hit();
			if(health <= 0) {
				Destroy(gameObject);
			}
		}
	}
	
	void Update() {
		float probability = shotsPerSecond * Time.deltaTime;
		if (Random.value < probability) {
			Fire ();
		}
	}
	
	void Fire() {
		Vector3 fire = transform.position;
		fire.y -= 1f;
		GameObject beam = Instantiate(projectile, fire, Quaternion.identity) as GameObject;
		beam.rigidbody2D.velocity = new Vector2(0f, -projectileSpeed);
	}
	
}
