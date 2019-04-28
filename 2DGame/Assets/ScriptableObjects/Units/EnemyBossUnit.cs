using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy",menuName="Unit/Boss Enemy")]
public class EnemyBossUnit : Unit {
	bool isSneaking = true;
	public float groundedDistance;

	public override void Think(UnitAI unitAI){
		unitAI.GetComponent<UnitControl>().distance = groundedDistance;
		
		//movement
		unitAI.GetComponent<UnitControl>().Control(speed, isSneaking, false);
		if(unitAI.GetComponent<UnitControl>().IsEdge(speed)){
			unitAI.GetComponent<UnitControl>().unitDirMod *= -1;
			//Debug.Log(unitAI.GetComponent<UnitControl>().unitDirMod);
		}
		if(unitAI.FacingUnit()==UnitAI.NearbyUnitType.Player){
			isSneaking = false;
			unitAI.GetComponent<UnitControl>().Control(0,isSneaking,false);
		}
		//jumping attack
		//float rngJump = Random.Range(0.0f,1.0f);


		//melee attack
		if(unitAI.FacingUnit()==UnitAI.NearbyUnitType.Player){
			unitAI.GetComponent<MeleeAttacks>().MeleeAttackAnimation();
		}
	}
}
