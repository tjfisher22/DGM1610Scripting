using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Unit : ScriptableObject {

	//public virtual void Initialize(UnitAI unit){}
	public abstract void Think(UnitAI unit);
	



	public new string name;

	public int maxHealth;
	//Not smart to store here, have current health built into floatvars and prefabs
	//public int currentHealth;
	public int strength;
	public int defense;
	public bool hostile = false;

	public float speed = 10;
	public float sprintModifier = 2;
	public float sneakModifier = .5f;
	public float jumpHeight = 10;

	public Sprite unitSprite;

	public Color unitColor = Color.black;

	//figure out if you can save animator controllers to SOs


	
}
