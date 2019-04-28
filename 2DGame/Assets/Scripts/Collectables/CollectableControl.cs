using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableControl : MonoBehaviour {

	public Collectables pickUp;
	public Inventory playerInventory;
	
	[HideInInspector]
	public int pickUpID;
	//public Inventory PlayerInventory; //Get a better name for this 
	public CollectListVariable possiblePickUps; //this should probably be a dictionary for quicker look up times
	[HideInInspector]
	public int CollectableValue;
	private SpriteRenderer collectSprite;
	//private Animator collectAnim;
	//private int animCollectType = 1;

	public bool pickedUp;
	

	// Use this for initialization
	void Start () {
		//pickedUp = false;
		pickUp = possiblePickUps.listValue[pickUpID];//would be cool to connect this to collectableAI script
		//set up the sprite for the object
		//This might be better in collectableManager
		//collectAnim = gameObject.GetComponent<Animator> ();
		collectSprite = gameObject.GetComponent<SpriteRenderer> ();
		collectSprite.sprite = pickUp.sprite;
		collectSprite.color = pickUp.color;
		collectSprite.sortingOrder = 100;
		//use this to determine what animation plays for each collectable
		// switch(pickUp.type){
		// 	case Collectables.CollectableType.Coin:
		// 		animCollectType = 0;
		// 		break;
		// 	case Collectables.CollectableType.Arrow:
		// 		animCollectType = 1;
		// 		break;
		// 	default:
		// 		Debug.Log("NoCollectType");
		// 		break;
		// }
		//collectAnim.SetInteger("CollectType", animCollectType);

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
	}
	public void PickUpCollect(Inventory playerInventory){
		// Debug.Log("Inventory");
		// switch(pickUp.type){// I don't think switch will be needed
		// 	case Collectables.CollectableType.Arrow:
		// 		break;
		// 	// case Collectables.CollectableType.Potion:
		// 	// 	break;
		// 	default:
		// 		Debug.Log("NoCollectType");
		// 		break;
		// }
		if(pickedUp){
			AddItem(pickUp, CollectableValue);
			Destroy(gameObject);
		}

	}
	void TooLow(){
		if(gameObject.transform.position.y < -25){
			Destroy(gameObject);
		}
	}
	public void AddItem(Collectables item, int amount){
		if(playerInventory.listValue.Contains(item)){//find if item is in list
			int inventoryIndex = playerInventory.listValue.FindIndex(x => x.Equals(item));//if so find it's index
			//Debug.Log("index " + inventoryIndex + "Amount "+amount);
			playerInventory.listValue2[inventoryIndex]+=amount;//and add to it's quantity
		}
		else{//if not 
			playerInventory.listValue.Add(item);//create new item slot  //limit max?
			playerInventory.listValue2.Add(amount);	//add quantity
		}

	}
}
