using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableControl : MonoBehaviour {

	public Collectables pickUp;
	[HideInInspector]
	public int pickUpID;
	//public Inventory PlayerInventory; //Get a better name for this 
	public CollectListVariable possiblePickUps; //this should probably be a dictionary for quicker look up times
	[HideInInspector]
	public int CollectableValue;
	private SpriteRenderer collectSprite;
	private Animator collectAnim;
	private int animCollectType = 1;

	public bool pickedUp;
	

	// Use this for initialization
	void Start () {
		//pickedUp = false;
		pickUp = possiblePickUps.listValue[pickUpID];//would be cool to connect this to collectableAI script
		// Debug.Log("Collectable name is: "+pickUp.name); //something here not working right
		// Debug.Log("Collectable name is: "+pickUp.color);
		// Debug.Log("Collectable name is: "+pickUp.sprite);
		//set up the sprite for the object
		//This might be better in collectableManager
		collectAnim = gameObject.GetComponent<Animator> ();
		collectSprite = gameObject.GetComponent<SpriteRenderer> ();
		collectSprite.sprite = pickUp.sprite;
		collectSprite.color = pickUp.color;
		collectSprite.sortingOrder = 100;
		switch(pickUp.type){
			case Collectables.CollectableType.Coin:
				animCollectType = 0;
				break;
			case Collectables.CollectableType.Arrow:
				animCollectType = 1;
				break;
			default:
				Debug.Log("NoCollectType");
				break;
		}
		collectAnim.SetInteger("CollectType", animCollectType);
		Debug.Log("Anim Collect Type = " + animCollectType);
	}
	// Update is called once per frame
	void Update () {
		TooLow();	
	}
	public void CollectValues(int value){
		CollectableValue = value;
		//Debug.Log("Collect Value" + CollectableValue);
	}
	//overload collectvalues for arrows
	void OnTriggerEnter2D(Collider2D other){
		//Debug.Log(other.gameObject.layer);
		if(other.gameObject.tag=="Enemy"){
			Destroy(gameObject);
		}
		if(other.gameObject.layer==LayerMask.NameToLayer("Death")){
			Destroy(gameObject);
		}
		if(other.gameObject.tag!="Player"){
			return;
		}
		else{
			pickedUp = true;
			
			//PickUpCollect();
		}
	}
	public void PickUpCollect(FloatVariable playerCoins){
		if(pickedUp){
			playerCoins.value += CollectableValue;
			Destroy(gameObject);
		}
		// switch(pickUp.type){
		// 	case Collectables.CollectableType.Coin:
		// 		//PlayerCollectables.value += CollectableValue;
		// 		break;
		// 	case Collectables.CollectableType.Arrow:
		// 		//Make an array of floatvariables for different arrow types
		// 		break;
		// 	default:
		// 		Debug.Log("NoCollectType");
		// 		break;
		// }
	}
	public void PickUpCollect(Inventory playerInventory){
		//switch(pickUp.type.ArrowType)

	}
	void TooLow(){
		if(gameObject.transform.position.y < -25){
			Destroy(gameObject);
		}
	}
}
