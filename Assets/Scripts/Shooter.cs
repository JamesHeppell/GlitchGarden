using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

	public GameObject projectile;
	public GameObject gun;
	
	private GameObject projectileParent;
	private Animator animator;
	private Spawner myLaneSpawner;
	
	void Start(){
		animator = GameObject.FindObjectOfType<Animator>();
		
		//Creates a parent is necessary
		projectileParent = GameObject.Find("Projectiles");
		if (projectileParent == null){
			projectileParent = new GameObject("Projectiles");
		}
		
		SetMyLaneSpawner();
	}
	
	void Update(){
		if (IsAttackerAheadInLane()){
			animator.SetBool("Is Attacking",true);
		}else {
			animator.SetBool("Is Attacking",false);
		}
	}
	
	//Look through all spawners, and set myLaneSpawner if found
	void SetMyLaneSpawner (){
		Spawner[] spawnerArray = GameObject.FindObjectsOfType<Spawner>();
		
		foreach (Spawner spawner in spawnerArray){
			if (spawner.transform.position.y == transform.position.y){
				myLaneSpawner = spawner;
				return;
			}
		}
		Debug.LogError(name + "can't find spawner in lane");
	}
	
	bool IsAttackerAheadInLane(){
		//Exit if no attackers in lane
		if (myLaneSpawner.transform.childCount <=0){
			return false;
		}
		
		//If there are attackers, are they ahead?
		foreach(Transform attacker in myLaneSpawner.transform){
			if (attacker.transform.position.x > transform.position.x){
				return true;
			}
		}
		
		//Attacker in Lane but behind us
		return false;
		
	}
	private void Fire () {
		GameObject newProjectile = Instantiate (projectile) as GameObject;
		newProjectile.transform.parent = projectileParent.transform;
		newProjectile.transform.position = gun.transform.position;
	}
	
}
