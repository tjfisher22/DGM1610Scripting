using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy",menuName="Unit/Patrol Enemy")]
public class EnemyPatrolUnit : Unit {
	Unit unitType;
	

	public override void Think(UnitAI unitAI){

		unitType = unitAI.GetComponent<UnitControl>().unit;
		//movement
		unitAI.GetComponent<UnitControl>().Control(1f, false, false);
		if(unitAI.GetComponent<UnitControl>().IsEdge(speed)){
			unitAI.GetComponent<UnitControl>().unitDirMod *= -1;
			Debug.Log(unitAI.GetComponent<UnitControl>().unitDirMod);
			
		}
		//jumping
		//melee attack
		if(false){
			unitAI.GetComponent<MeleeAttacks>().MeleeAttack();
		}

		
	}
}
