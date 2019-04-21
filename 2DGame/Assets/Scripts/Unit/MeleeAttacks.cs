using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttacks : MonoBehaviour {

	public Unit attacker;
	public Weapon weapon; 

	public float timeToAttack;
	public float attackCooldown;

	public Transform attackReach;
	public LayerMask enemyLayer;
	[HideInInspector]public float attackSize;
	public int damage;

	private Animator attackerAnim;

	public bool onCooldown;
	
	
	//float distance = 2f;
	//public Vector2 direction = new Vector2(0,-1*distance);
	public Vector2 position;

	// Use this for initialization
	void Start () {
		attackCooldown = weapon.attackCooldown;
		attackerAnim = gameObject.GetComponent<Animator> ();
		attackSize = weapon.weaponSize;
		onCooldown = false;
		

    	
	}
	
	// Update is called once per frame
	void Update () {
		

	}

	public void MeleeAttack(){
		if(!onCooldown){
				attackerAnim.SetTrigger("slash");
				damage = weapon.damage + attacker.strength;
				Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackReach.position, attackSize, enemyLayer);
				for (int i = 0; i< enemiesToDamage.Length; i++){
					enemiesToDamage[i].GetComponent<UnitControl>().TakeDamage(damage);
				}
				StartCoroutine(Cooldown());
				// timeToAttack = attackCooldown;			
		}
		else{
			//timeToAttack--;
		}
	}

	private IEnumerator Cooldown(){
		onCooldown = true;

		yield return new WaitForSeconds(attackCooldown);

		onCooldown = false;
	}
	

}
