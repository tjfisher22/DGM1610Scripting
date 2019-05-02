﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttacks : MonoBehaviour {
 	public Weapon weapon; 
	public Unit attacker;

	public float timeToAttack;
	public float attackCooldown;

	public Transform attackReach;
	public LayerMask enemyLayer;
	[HideInInspector]
	public float attackSize;
	[HideInInspector]
	public int damage;

	private Animator attackerAnim;
	[HideInInspector]
	public bool onCooldown;
	[HideInInspector]
	public Vector2 position;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	}
	public void MeleeAttackAnimation(){
		if(!onCooldown){
		attackerAnim = gameObject.GetComponent<Animator>();
		attackerAnim.SetTrigger("slash");
		StartCoroutine(Cooldown());
		}
	}
	public void MeleeAttack(){
		//unused

		// if(!onCooldown){
		// 		//attackerAnim = gameObject.GetComponent<Animator>();
		// 		//attackerAnim.SetTrigger("slash");
		// 		damage = weapon.damage + attacker.strength;
		// 		//Debug.Log("Attacked");
		// 		Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackReach.position, attackSize, enemyLayer);
		// 		for (int i = 0; i< enemiesToDamage.Length; i++){
		// 			enemiesToDamage[i].GetComponent<UnitControl>().TakeDamage(damage,gameObject.transform.localScale.x,weapon.knockbackTime);
		// 		}
		// 		StartCoroutine(Cooldown());
		// 		// timeToAttack = attackCooldown;			
		// }
		// else{
		// 	//timeToAttack--;
		// }
	}

	private IEnumerator Cooldown(){
		onCooldown = true;

		yield return new WaitForSeconds(weapon.attackCooldown);

		onCooldown = false;
	}
	

}
