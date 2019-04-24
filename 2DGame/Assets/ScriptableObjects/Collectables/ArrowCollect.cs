using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Arrow", menuName = "Collectables/Arrow")]
public class ArrowCollect : Collectables {
	public enum ArrowType {Normal, Fire, Ice}
	public ArrowType arrowType;
	public int arrowDamage;
	public float knockBack;

	//type = Collectables.CollectableType.Arrow;



	// Put spawning in collectableManager
	// public override void Spawn(CollectableAI Collect){

	// }
	public override void Collect(CollectableAI pickUp){
			pickUp.GetComponent<CollectableControl>().CollectValues(amount);

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
