using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Unit", menuName = "Unit")]
public class Unit : ScriptableObject {

	public new string name;

	public int maxHealth;
	//Not smart to store here, have current health built into prefabs of units
	//public int currentHealth;
	public int strength;
	public bool hostile = false;

	public float speed = 10;
	public float sprintModifier = 2;
	public float sneakModifier = .5f;
	public float jumpHeight = 10;

	public Sprite unitSprite;

	
}
