﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Collectables : ScriptableObject {
	public enum CollectableType {Coin, Arrow, PowerUp, Potion};//not readily expandable //Scriptable object would be better but required for the assignment

	public string name = "New Collectable";
	public Sprite sprite;
	public int amount = 1;
	public Inventory playerInventory;
	//move to coinsSO
	//public int cValue;
	public CollectableType type;
	public Color color = Color.black;
	public RuntimeAnimatorController animControl;
	//private bool pickedUp;

	//public virtual void Initialize(UnitAI unit){}
	// public abstract void Spawn(CollectableAI Collect);
	public abstract void Collect(CollectableAI pickUp);
	public virtual float duration{get;}

}
