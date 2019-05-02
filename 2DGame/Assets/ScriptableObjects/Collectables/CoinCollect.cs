using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Coin", menuName = "Collectables/Coin")]
public class CoinCollect : Collectables {
	public int coinValue;
	public FloatVariable playerCoins;

	public override void Collect(CollectableAI pickUp){
			//Collect is run in CoinAI Update
			pickUp.GetComponent<CollectableControl>().CollectValues(coinValue*amount);
			pickUp.GetComponent<CollectableControl>().PickUpCollect(playerCoins);
			//put collectable specific stuff here
			//Like add powerups, add to score.
			//They will functions to call from CollectableControl I believe
			//Nah, just pass important values into Collect()
			//Or is that too much info for the class
			//Keep it here if possible
			//NOPE
			//Send the important stuff 

	}


}




