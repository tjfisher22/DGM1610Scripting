using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Collectables : ScriptableObject {
	//abstract scriptable object for all pickups.
	//General info here with specifics implemented in each base class
	public enum CollectableType {Coin, Arrow, PowerUp, Potion};

	public string name = "New Collectable";
	public Sprite sprite;
	public int amount = 1;
	public Inventory playerInventory;

	public CollectableType type;
	public Color color = Color.black;
	public RuntimeAnimatorController animControl;

	//public virtual void Initialize(UnitAI unit){}
	// public abstract void Spawn(CollectableAI Collect);
	public abstract void Collect(CollectableAI pickUp);
	//public virtual float duration{get;}


}
