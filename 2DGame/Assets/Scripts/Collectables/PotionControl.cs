using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionControl : MonoBehaviour {
	
	//public PotionCollect potion;
	private SpriteRenderer potionSprite;
	public Inventory playerInventory;
	public CollectVariable selectedPotion;
	public FloatVariable effectDuration;
	bool potionInUse;


	void Start(){
		// potionSprite = gameObject.GetComponent<SpriteRenderer> ();
		// potionSprite.sprite = potion.sprite;
		// potionSprite.color = potion.color;
		// potionSprite.sortingOrder = 100;
	}
	// Update is called once per frame
	void Update () {
		
	}
	public void UsePotion(){
		if(playerInventory.listValue.Contains(selectedPotion.collectable)&&!potionInUse){
			int inventoryIndex = playerInventory.listValue.FindIndex(x => x.Equals(selectedPotion));
			//Debug.Log("index " + inventoryIndex + "Amount "+amount);
			//turn bar background on
			playerInventory.listValue2[inventoryIndex]--;
			StartCoroutine(PotionEffect());
		}
		else{
			Debug.Log("No potions??");
		}
	}
	IEnumerator PotionEffect(){
		float timeRemaining = selectedPotion.collectable.duration;
		potionInUse = true;
		effectDuration.value = timeRemaining;
		while(timeRemaining>0){
			//shrink bar
			timeRemaining -= Time.deltaTime;
			
			//display text
			yield return null;
		}
		//do ui stuff
		//do potion effect

		// yield return new WaitForSeconds(selectedPotion.collectable.duration);

		//reset potion effect

		potionInUse = false;

	}

	public void scrollPotions(){ //maybe put in inventory manager

	}
}
