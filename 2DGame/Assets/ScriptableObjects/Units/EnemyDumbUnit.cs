using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Enemy",menuName="Unit/Dumb Enemy")]
public class EnemyDumbUnit : Unit {
	Unit unitType; //why is this here?
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
		if(unitAI.FacingUnit()!=UnitAI.NearbyUnitType.Player){
			if(unitAI.GetComponent<UnitControl>().IsEdge(speed)){
				unitAI.GetComponent<UnitControl>().Jump();
			}
			else{
				unitAI.GetComponent<UnitControl>().Control(speed, false, false);
			}
		}
		else{unitAI.GetComponent<UnitControl>().Control(0, false, false); }
		//melee attack
		//call unitAI.IsNearEnemy here

		if(unitAI.FacingUnit()==UnitAI.NearbyUnitType.Player){
			unitAI.GetComponent<MeleeAttacks>().MeleeAttackAnimation();
		}
	}
}
