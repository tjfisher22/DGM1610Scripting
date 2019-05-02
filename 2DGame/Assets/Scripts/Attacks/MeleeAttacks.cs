using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttacks : MonoBehaviour {
	//Control for attacking from melee range

 	public Weapon weapon; 
	public Unit attacker;
	public FloatListVariable playerCooldown;

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

	void Start () {
		playerCooldown.value = weapon.attackCooldown;
		playerCooldown.listValue[0] = weapon.attackCooldown;
	}
	
	void Update () {
	}

	public void MeleeAttackAnimation(){
		if(!onCooldown){
		attackerAnim = gameObject.GetComponent<Animator>();
		attackerAnim.SetTrigger("slash"); //can be used in combination with scriptable object to change trigger for each. Thereby letting the player have different animations with different weapons
		StartCoroutine(Cooldown());
		}
	}
	public void MeleeAttack(){
		//unused  //Damage is calculated via ontrigger enter in MeleeControl

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
		float timeRemaining =weapon.attackCooldown; 
		while(timeRemaining>0){
			playerCooldown.listValue[0] = timeRemaining;
			timeRemaining -= Time.deltaTime;
			yield return null;
		}
				
		// yield return new WaitForSeconds(weapon.attackCooldown);

		onCooldown = false;
		playerCooldown.listValue[0] = weapon.attackCooldown;
	}
	

}
