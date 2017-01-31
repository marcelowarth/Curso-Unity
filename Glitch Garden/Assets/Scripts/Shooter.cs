using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

	public GameObject projectile, gun;
	
	private GameObject projectileParent;
	private Animator animator;
	private SpawnAttackers myLaneSpawner;
	
	void Start() {
		animator = GetComponent<Animator>();
		projectileParent = GameObject.Find ("Projectiles");
		if(!projectileParent) {
			projectileParent = new GameObject("Projectiles");
		}
		SetMyLaneSpawner();
	}
	
	void Update() {
		if(IsAttackerAhead()) {
			animator.SetBool("isAttackingBool", true);
		} else {
			animator.SetBool("isAttackingBool", false);
		}
	}
	
	bool IsAttackerAhead() {
		if(myLaneSpawner.transform.childCount <= 0) {
			return false;
		}
		
		foreach(Transform attackers in myLaneSpawner.transform) {
			if(attackers.transform.position.x > transform.position.x) {
				return true;
			}
		}
		
		return false;
	}
	
	void SetMyLaneSpawner() {
		SpawnAttackers[] spawnerArray = GameObject.FindObjectsOfType<SpawnAttackers>();
		foreach(SpawnAttackers spawner in spawnerArray) {
			if(spawner.transform.position.y == transform.position.y) {
				myLaneSpawner = spawner;
				return;
			}
		}
		Debug.LogError(name + " cant find Spawner in lane");
	}
	
	private void FireGun() {
		GameObject newProjectile = Instantiate(projectile) as GameObject;
		newProjectile.transform.parent = projectileParent.transform;
		newProjectile.transform.position = gun.transform.position;
	}
}
