using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Potion", menuName = "Collectables/Potion")]
public class PotionCollect : Collectables {
	public enum PotionType {Health, Speed, Jump, Strength, Defense}
	public PotionType potionType;
	public float duration;
	public int cost;
	public bool isPoison;
	// public float potionDuration; // this wasn't needed in the end
	// public override float duration{
	// 	get{
	// 		return potionDuration;
	// 	}
	// }
	[Range(1,3)]
	public int tier = 1;





	public override void Collect(CollectableAI pickUp){
			//Collect is run in potionAI Update
			pickUp.GetComponent<CollectableControl>().CollectValues(amount);
			pickUp.GetComponent<CollectableControl>().PickUpCollect(playerInventory);
	}

}
