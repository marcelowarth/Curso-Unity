using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {

	public float health = 150f;
	public GameObject projectile;
	public float projectileSpeed = 5f;
	public float shotsPerSecond = 0.5f;
	public int score = 25;
	public AudioClip shot;
	public AudioClip die;
	
	private ScoreKeeper scoreKeeper;
	
	void Start() {
		scoreKeeper = GameObject.Find("ScoreValue").GetComponent<ScoreKeeper>();
	}

	void OnTriggerEnter2D(Collider2D coll) {
		Projectile missile = coll.gameObject.GetComponent<Projectile>();
		if (missile) {
			health -= missile.GetDamage();
			missile.Hit();
			if(health <= 0) {
				Die();
			}
		}
	}
	
	void Die() {
		scoreKeeper.Score(score);
		AudioSource.PlayClipAtPoint(die, transform.position);
		Destroy(gameObject);
	}
	
	void Update() {
		float probability = shotsPerSecond * Time.deltaTime;
		if (Random.value < probability) {
			Fire ();
		}
	}
	
	void Fire() {
		GameObject beam = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
		beam.rigidbody2D.velocity = new Vector2(0f, -projectileSpeed);
		AudioSource.PlayClipAtPoint(shot, transform.position);
	}
	
}
