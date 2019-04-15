using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Collectables : ScriptableObject {
	public enum CollectableType {Coin, Arrow, PowerUp, Potion};

	public string Name = "New Collectable";
	public Sprite Sprite;
	public int Amount;
	//move to coinsSO
	//public int cValue;
	public CollectableType type;

	//public virtual void Initialize(UnitAI unit){}
	// public abstract void Spawn(CollectableAI Collect);
	public abstract void Collect(CollectableAI pickUp);

}
