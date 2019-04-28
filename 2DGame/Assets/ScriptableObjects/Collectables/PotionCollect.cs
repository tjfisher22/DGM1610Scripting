using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Potion", menuName = "Collectables/Potion")]
public class PotionCollect : Collectables {
	public enum PotionType {Health, Speed, Jump, Strength, Defence}
	public PotionType potionType;
	//public Unit player;
	public float potionDuration;
	public override float duration{
		get{
			return potionDuration;
		}
	}
	[Range(1,3)]
	public int tier;





	public override void Collect(CollectableAI pickUp){
			pickUp.GetComponent<CollectableControl>().CollectValues(amount);
			pickUp.GetComponent<CollectableControl>().PickUpCollect(playerInventory);
	}

}
