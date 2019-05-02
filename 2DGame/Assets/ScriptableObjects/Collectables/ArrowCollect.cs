using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Arrow", menuName = "Collectables/Arrow")]
public class ArrowCollect : Collectables {
	public enum ArrowType {Normal, Fire, Ice}
	public ArrowType arrowType;
	public int arrowDamage;
	public float knockBack;
	public int cost;

	public override void Collect(CollectableAI pickUp){
			//Collect is run in arrowAI Update
			pickUp.GetComponent<CollectableControl>().CollectValues(amount);
			pickUp.GetComponent<CollectableControl>().PickUpCollect(playerInventory);

	}
}
