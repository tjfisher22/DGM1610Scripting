using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotionControl : MonoBehaviour {
	
	//public PotionCollect potion;
	public Unit player;
	private SpriteRenderer potionSprite;
	public Inventory playerInventory;
	public CollectVariable selectedPotion;
	public FloatListVariable effectDuration;
	public FloatListVariable playerHealth;
	bool potionInUse;
	public Transform effectBar;
	//[HideInInspector]
	PotionCollect usedPotion;
	[HideInInspector]
	public float priorValue = 0;

	void Start(){
		effectBar.gameObject.SetActive(false);
		// potionSprite = gameObject.GetComponent<SpriteRenderer> ();
		// potionSprite.sprite = potion.sprite;
		// potionSprite.color = potion.color;
		// potionSprite.sortingOrder = 100;

		
	}
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("QuickItem")) // I'd like to move this to PlayerUnit so it can be accessed by each unit individually
			UsePotion();
		//StartCoroutine(PotionEffect());}
		
	}
	public void UsePotion(){
		if(selectedPotion.collectable is PotionCollect){
			usedPotion = selectedPotion.collectable as PotionCollect;
		}
		if(playerInventory.listValue.Contains(usedPotion)&&!potionInUse){
			int inventoryIndex = playerInventory.listValue.FindIndex(x => x.Equals(usedPotion));
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
		potionInUse = true;
		effectBar.gameObject.SetActive(true);
		effectBar.GetChild(0).gameObject.GetComponent<Image>().color = usedPotion.color;
		float timeRemaining = usedPotion.duration;
		
		effectDuration.value = usedPotion.duration;

		int tier = usedPotion.tier;
		bool healthPot = false;
		//ADD THE EFFECT TO THE PLAYER {Health, Speed, Jump, Strength, Defence}
		switch(usedPotion.potionType){
			case PotionCollect.PotionType.Health:
				healthPot = true;
				break;
			case PotionCollect.PotionType.Speed:
				priorValue = player.speed;
				player.speed *=(1f+(float)tier/3);
				break;
			case PotionCollect.PotionType.Jump:
				priorValue = player.jumpHeight;
				player.jumpHeight *=(1.5f+(float)tier/3);
				break;
			case PotionCollect.PotionType.Strength:
				break;		
			case PotionCollect.PotionType.Defence:
				break;			
		}

		while(timeRemaining>0){
			if(healthPot){
				if(playerHealth.listValue[0]<100)
					playerHealth.listValue[0]+=(.25f*tier);
				else playerHealth.listValue[0] = 100;
				}
			//shrink bar variable
			effectDuration.listValue[0]=timeRemaining;
			timeRemaining -= Time.deltaTime;
			if(playerHealth.listValue[0] <= 0){
				break;
			}
			yield return null;
		}
		// yield return new WaitForSeconds(selectedPotion.collectable.duration);
		//reset potion effect
		switch(usedPotion.potionType){
			case PotionCollect.PotionType.Speed:
				player.speed = priorValue;
				break;
			case PotionCollect.PotionType.Jump:
				player.jumpHeight = priorValue;
				break;
			case PotionCollect.PotionType.Strength:
				break;		
			case PotionCollect.PotionType.Defence:
				break;			
		}

		potionInUse = false;
		effectBar.gameObject.SetActive(false);
		priorValue = 0;

	}

	public void scrollPotions(){ //maybe put in inventory manager

	}
}
