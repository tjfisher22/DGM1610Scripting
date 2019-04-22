using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Enemy",menuName="Unit/Dumb Enemy")]
public class EnemyDumbUnit : Unit {
	Unit unitType;
	// [Range(0, 10)]
	// public float idleTime;
	// [Range(0, 10)]
	// public float moveTime;
	// [Range(0, 10)]
	// public float attackTime;
	// public enum States {Idle, Walking, Attacking, Jumping};
	public override void Think(UnitAI unitAI){
		unitType = unitAI.GetComponent<UnitControl>().unit; 
		//movement
		//jumping
		if(unitAI.GetComponent<UnitControl>().IsEdge(speed)){
			unitAI.GetComponent<UnitControl>().Jump();
		}
		else{
			unitAI.GetComponent<UnitControl>().Control(1f, false, false);
		}
		//melee attack
		if(true){
			unitAI.GetComponent<MeleeAttacks>().MeleeAttackAnimation();
		}
	}
}
