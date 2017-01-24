using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	public float velocity = 15.0f;
	public float padding = 1f;
	public GameObject projectile;
	public float projectileSpeed;
	public float firingRate = 10f;
	public float health = 250f;
	public AudioClip shot;
	
	private float xMin, xMax;
	
	// Use this for initialization
	void Start () {
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftMost = Camera.main.ViewportToWorldPoint(new Vector3(0,0,distance));
		Vector3 rightMost = Camera.main.ViewportToWorldPoint(new Vector3(1,0,distance));
		xMin = leftMost.x + padding;
		xMax = rightMost.x - padding;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) {
			InvokeRepeating("Fire", 0.0001f, firingRate);
		}
		if (Input.GetKeyUp(KeyCode.Space)) {
			CancelInvoke("Fire");
		}
		
		if(Input.GetKey(KeyCode.LeftArrow)) {
			transform.position += Vector3.left * velocity * Time.deltaTime;
		} else if(Input.GetKey(KeyCode.RightArrow)) {
			transform.position += Vector3.right * velocity * Time.deltaTime;
		}
		
		// Restrict to game space
		float newX = Mathf.Clamp(transform.position.x, xMin, xMax);
		transform.position = new Vector3(newX, transform.position.y, transform.position.z);
	}
	
	void Fire() {
		GameObject beam = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
		beam.GetComponent<Rigidbody2D>().velocity = new Vector3(0f, projectileSpeed, 0f);
		AudioSource.PlayClipAtPoint(shot, transform.position);
	}
	
	void OnTriggerEnter2D(Collider2D coll) {
		Projectile missile = coll.gameObject.GetComponent<Projectile>();
		if (missile) {
			health -= missile.GetDamage();
			missile.Hit();
			if(health <= 0) {
				Die ();
			}
		}
	}
	
	void Die() {
		LevelManager man = GameObject.Find("LevelManager").GetComponent<LevelManager>();
		man.LoadLevel("Win");
		Destroy(gameObject);
	}
	
}
