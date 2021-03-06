﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Player", menuName = "Unit/Player Unit")]
public class PlayerUnit : Unit {
	//Controls for the player charater
	public int playerNumber;
	private string movementAxisName;
	private string jumpAxisName;
	private string meleeButton;
	private string sneakButton;
	private string sprintButton;
	private string quickItem;


	public void OnEnable()
	{
		//can add player number to end of strings to allow for multiple player inputs to be set up
		movementAxisName = "Horizontal";
		jumpAxisName = "Jump";
		meleeButton = "Melee";
		sneakButton = "Sneak";
		sprintButton = "Sprint";
		quickItem = "QuickItem";
	}

	public override void Think(UnitAI unit){
		//Think is called from UnitAI

		//movement
		unit.GetComponent<UnitControl>().Control(Input.GetAxis(movementAxisName),false /*Input.GetButton(sneakButton) */,Input.GetButton(sprintButton)); //removing sneak since animation is not in and there isn't a purpose for it currently

		//jumping
		if(Input.GetButtonDown(jumpAxisName)){
			unit.GetComponent<UnitControl>().Jump();
		}

		//melee attack
		if(Input.GetButtonDown(meleeButton)){
			//unit.GetComponent<MeleeAttacks>().MeleeAttack(unitType);
			unit.GetComponent<MeleeAttacks>().MeleeAttackAnimation();
		}

		//potion usage
		// if(Input.GetButtonDown(quickItem)){
		// 	unit.GetComponent<PotionControl>().UsePotion(); //attached potion control to inventory manager instead but should move back for player modularity in the future. Potentially called from shared inventory scriptable object?
		// }

		//fire arrow
	}


}
