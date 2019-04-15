using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolUnit : Unit {

	public override void Think(UnitAI unit){

		//movement
		unit.GetComponent<UnitControl>().Control(-.1f, false, false);

		//jumping
		if(false){
			unit.GetComponent<UnitControl>().Jump();
		}

		//melee attack
		if(false){
			unit.GetComponent<MeleeAttacks>().MeleeAttack();
		}

		
	}
}
