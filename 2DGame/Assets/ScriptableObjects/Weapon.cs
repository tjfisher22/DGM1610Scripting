using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon")]
public class Weapon : ScriptableObject {

	public string weaponName = "New Weapon";
	
	public Sprite weaponSprite;
	
	public int damage;
	public float attackCooldown;
	public float knockbackTime;

	public float weaponSize;
	public float weaponReach;

}
