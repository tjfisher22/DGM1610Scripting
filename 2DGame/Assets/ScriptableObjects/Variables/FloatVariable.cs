using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Float", menuName = "Variable/Float")]
//Used to store floats across the scene
//IE player health doesn't need to be called from the player, merely sent to the central location with all relevant scripts updating acordingly
public class FloatVariable : ScriptableObject {

	public string description;
	public float value;



	
}
