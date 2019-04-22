using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableControl : MonoBehaviour {
	public bool pickedUp;
	public Collectables pickUp;
	public int pickUpID;
	public CollectListVariable PlayerCollectables; //Get a better name for this 
	public CollectListVariable possiblePickUps; //this should probably be a dictionary for quicker look up times
	[HideInInspector]
	public int CollectableValue;
	private SpriteRenderer collectSprite;
	

	// Use this for initialization
	void Start () {
		pickUp = possiblePickUps.listValue[pickUpID];
		//set up the sprite for the object
		//This might be better in collectableManager
		collectSprite = gameObject.GetComponent<SpriteRenderer> ();
		collectSprite.sprite = pickUp.sprite;
		collectSprite.color = pickUp.color;
		collectSprite.sortingOrder = 100;
	}
	// Update is called once per frame
	void Update () {
		TooLow();
	}
	public void CollectValues(int value){
		CollectableValue = value;
	}
	void OnTriggerEnter2D(Collider2D other){
		//Debug.Log(other.gameObject.layer);
		if(other.gameObject.tag!="Player"){
			return;
		}
		if(other.gameObject.tag!="Enemy"){
			Destroy(gameObject);
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
				//PlayerCollectables.value += CollectableValue;
				break;
			case Collectables.CollectableType.Arrow:
				//Make an array of floatvariables for different arrow types
				break;
			default:
				Debug.Log("NoCollectType");
				break;
		}
		Destroy(gameObject);
	}
	void TooLow(){
		if(gameObject.transform.position.y < -15){
			Destroy(gameObject);
		}
	}
}
