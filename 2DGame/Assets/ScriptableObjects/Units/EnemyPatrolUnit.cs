using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy",menuName="Unit/Patrol Enemy")]
public class EnemyPatrolUnit : Unit {
	//Unit unitType;//I don't think I need this
	

	public override void Think(UnitAI unitAI){

		//unitType = unitAI.GetComponent<UnitControl>().unit;
		//movement
		unitAI.GetComponent<UnitControl>().Control(speed, false, false);
		if(unitAI.GetComponent<UnitControl>().IsEdge(speed)){
			unitAI.GetComponent<UnitControl>().unitDirMod *= -1;
			//Debug.Log(unitAI.GetComponent<UnitControl>().unitDirMod);
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
