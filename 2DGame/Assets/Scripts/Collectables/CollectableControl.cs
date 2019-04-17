﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableControl : MonoBehaviour {
	public bool pickedUp;
	public Collectables pickUp;
	public FloatVariable PlayerCollectables; //Get a better name for this
	[HideInInspector]
	public int CollectableValue;
	private SpriteRenderer collectSprite;
	

	// Use this for initialization
	void Start () {
		//set up the sprite for the object
		//This might be better in collectableManager
		collectSprite = gameObject.GetComponent<SpriteRenderer> ();
		collectSprite.sprite = pickUp.sprite;
		collectSprite.color = pickUp.color;
		collectSprite.sortingOrder = 100;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void CollectValues(int value){
		
		CollectableValue = value;
		//destroy object
		// if(pickedUp){
		// 	Debug.Log("Destroy Up");
		// 	Destroy(gameObject);
		// }
		


	}

	void OnTriggerEnter2D(Collider2D other){
		//Debug.Log(other.gameObject.layer);
		if(other.gameObject.tag!="Player"){
			return;
		}
		else{
			//bool pickedUp = true;
			//Debug.Log("Picked Up");
			PickUpCollect();
		}
	}
	
	void PickUpCollect(){

		switch(pickUp.type){
			case Collectables.CollectableType.Coin:
				PlayerCollectables.value += CollectableValue;
				break;
			case Collectables.CollectableType.Arrow:
				//Make an array of floatvariables for different arrow types
				break;
			default:
				Debug.Log("NoCollectType");
				break;
		}

		Debug.Log("Destroy Up");
		Destroy(gameObject);


	}
}
