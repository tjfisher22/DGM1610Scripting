using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Player", menuName = "Unit/Player Unit")]
public class PlayerUnit : Unit {

	public int playerNumber;
	private string movementAxisName;
	private string jumpAxisName;
	private string meleeButton;
	private string sneakButton;
	private string sprintButton;


	public void OnEnable()
	{
		//can add player number to end of strings to allow for multiple player inputs to be set up
		movementAxisName = "Horizontal";
		jumpAxisName = "Jump";
		meleeButton = "Melee";
		sneakButton = "Sneak";
		sprintButton = "Sprint";
	}

	public override void Think(UnitAI unit){

		//movement
		unit.GetComponent<UnitControl>().Control(Input.GetAxis(movementAxisName),Input.GetButton(sneakButton),Input.GetButton(sprintButton));

		//jumping
		if(Input.GetButtonDown(jumpAxisName)){
			unit.GetComponent<UnitControl>().Jump();
		}

		//melee attack
		if(Input.GetButtonDown(meleeButton)){
			unit.GetComponent<MeleeAttacks>().MeleeAttack();
		}

		
	}


}
