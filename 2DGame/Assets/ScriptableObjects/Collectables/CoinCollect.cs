using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Coin", menuName = "Collectables/Coin")]
public class CoinCollect : Collectables {
	public int coinValue;

	// Put spawning in collectableManager
	// public override void Spawn(CollectableAI Collect){

	// }
	public override void Collect(CollectableAI pickUp){
			pickUp.GetComponent<CollectableControl>().Collect(pickUp);

	}


}




