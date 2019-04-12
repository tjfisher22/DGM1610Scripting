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

	public float speed;
	public float jumpHeight;

	public Sprite unitSprite;

	
}
