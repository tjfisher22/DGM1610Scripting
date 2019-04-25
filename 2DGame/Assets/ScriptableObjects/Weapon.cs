using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon")]
public class Weapon : ScriptableObject {

	public string weaponName = "New Weapon";
	
	public Sprite sprite;
	public Color color = Color.black;
	
	public int damage;
	public float attackCooldown;
	public float knockbackTime;
	public float knockBack;


	// public float weaponSize;
	// public float weaponReach;

}
