using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Enemy",menuName="Unit/Dumb Enemy")]
public class EnemyDumbUnit : Unit {
	//control for enemy that jumps along platforms
	
	// Use in the future for randomizing AI
	// [Range(0, 10)]
	// public float idleTime;
	// [Range(0, 10)]
	// public float moveTime;
	// [Range(0, 10)]
	// public float attackTime;
	// public enum States {Idle, Walking, Attacking, Jumping};
	public override void Think(UnitAI unitAI){
		//Think is run in UnitAI's update
		//movement
		//Unit Detection
		if(unitAI.FacingUnit()!=UnitAI.NearbyUnitType.Player){
			if(unitAI.FacingUnit()==UnitAI.NearbyUnitType.Enemy){
				unitAI.GetComponent<UnitControl>().unitDirMod *= -1; //Turn around if facing an enemy
			}
			if(unitAI.GetComponent<UnitControl>().IsEdge(speed)){ //Jump at edges
				unitAI.GetComponent<UnitControl>().Jump();
			}
			else{
				unitAI.GetComponent<UnitControl>().Control(speed, false, false); //send speed to unit control with no sneak or sprint mods
			}
		}
		//melee attack
		//if the player is in the colision radius, stop and attack
		if(unitAI.FacingUnit()==UnitAI.NearbyUnitType.Player){
			unitAI.GetComponent<UnitControl>().Control(0, false, false);
			unitAI.GetComponent<MeleeAttacks>().MeleeAttackAnimation();
		}
	}
}
