using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Enemy",menuName="Unit/DumbEnemy")]
public class EnemyDumbUnit : Unit {

	// [Range(0, 10)]
	// public float idleTime;
	// [Range(0, 10)]
	// public float moveTime;
	// [Range(0, 10)]
	// public float attackTime;

	// public enum States {Idle, Walking, Attacking, Jumping};



	public override void Think(UnitAI unit){


		//movement
		

		//jumping
		if(unit.GetComponent<UnitControl>().IsEdge(speed)){
			unit.GetComponent<UnitControl>().Jump();
		}
		else{
			unit.GetComponent<UnitControl>().Control(-1f, false, false);
		}
		

		//melee attack
		if(true){
			unit.GetComponent<MeleeAttacks>().MeleeAttack();
		}

		
	}




}
