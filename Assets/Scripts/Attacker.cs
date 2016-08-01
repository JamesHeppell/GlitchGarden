using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody2D))]
public class Attacker : MonoBehaviour {
	
	
	private float currentSpeed;
	[Tooltip ("avg num of seconds between appearances")]
	public float seenEverySeconds;
	private GameObject currentTarget;
	private Animator animator;
	
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.left * currentSpeed * Time.deltaTime);
		if (!currentTarget) {
			animator.SetBool ("Is Attacking", false);
		}
	}
	
	void OnTriggerEnter2D () {
		
	}
	
	
	public void SetSpeed (float speed){
		currentSpeed = speed;
	}
	
	// Called from the enimator while attacking
	public void StrikeCurrentTarget(float damage){
		if (currentTarget) {
			Health health = currentTarget.GetComponent<Health>();
			if (health) {
				health.DealDamage (damage);
				//Debug.Log(currentTarget + " has " + health.GetHealth() + " health left");
			}
		}
	}
	
	public void Attack (GameObject obj){
		currentTarget = obj;
		
	}
	
}
