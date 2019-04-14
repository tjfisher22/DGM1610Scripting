using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttacks : MonoBehaviour {

	public Unit attacker;
	public Weapon weapon; 

	float timeToAttack;
	public float attackCooldown;

	public Transform attackReach;
	public LayerMask enemyLayer;
	[HideInInspector]public float attackSize;
	
	
	float distance = 2f;
	//public Vector2 direction = new Vector2(0,-1*distance);
	Vector2 position;

	// Use this for initialization
	void Start () {
		attackCooldown = weapon.attackCooldown;
		

    	
	}
	
	// Update is called once per frame
	void Update () {
		//position = gameObject.transform.position;
		if(timeToAttack <=0){
			if(Input.GetButtonDown("Melee")){
				
				//Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll
			}

			timeToAttack = attackCooldown;
		}
		else{
			timeToAttack--;
		}
	}
}
