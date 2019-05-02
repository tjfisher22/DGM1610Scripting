using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy",menuName="Unit/Patrol Enemy")]
public class EnemyPatrolUnit : Unit {
	//control for enemy that paces along platforms
	public override void Think(UnitAI unitAI){
	//Think is run in UnitAI's update
		//movement
		unitAI.GetComponent<UnitControl>().Control(speed, false, false);
		if(unitAI.GetComponent<UnitControl>().IsEdge(speed)){
			unitAI.GetComponent<UnitControl>().unitDirMod *= -1;
		}
		if(unitAI.FacingUnit()==UnitAI.NearbyUnitType.Player){
			unitAI.GetComponent<UnitControl>().Control(0,false,false);
		}
		//jumping
		//melee attack
		if(unitAI.FacingUnit()==UnitAI.NearbyUnitType.Player){
			unitAI.GetComponent<MeleeAttacks>().MeleeAttackAnimation();
		}

		
	}
}
