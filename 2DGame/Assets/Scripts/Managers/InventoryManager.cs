using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour {
	//manages given inventory


	//shouldl probably make an instance of this
	//list potions
	//list arrows
	//list length of each checked until new length is longer
	//check to see if new item is potion or arrow
	//add it if so skip if not



	public Inventory playerInventory;
	bool scrollUp = false;
	public CollectVariable selectedPotion;

	List<Collectables> inventoryPotions = new List<Collectables>();
	int potIndex = 1; //set to 1 because I initialize the UI selection using scrollItem(down)
	List<Collectables> inventoryArrows = new List<Collectables>();
	int arrIndex = 1;

	// Use this for initialization
	void Start () {
		ScrollItem();
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Inventory")){
			//open inventory
		}
		if(Input.GetAxis("Mouse ScrollWheel")<0f){
			scrollUp = false;
			ScrollItem();
		}
		else if(Input.GetAxis("Mouse ScrollWheel")>0f){
			scrollUp = true;
			ScrollItem();
		}
		else{

		}
		
	}

	public void AddItem(Collectables item, int amount){  //overload this with a list as well
		if(playerInventory.listValue.Contains(item)){//find if item is in list
			int inventoryIndex = playerInventory.listValue.FindIndex(x => x.Equals(item));//if so find it's index
			playerInventory.listValue2[inventoryIndex]+=amount;//and add to it's quantity
		}
		else{//if not 
			playerInventory.listValue.Add(item);//create new item slot  //limit max?
			playerInventory.listValue2.Add(amount);	//add quantity
		}

	}
	public void ScrollItem(){
		//use if statment here to brance off into arrows
		for(int i = 0; i<playerInventory.listValue.Count; i++){
			if(playerInventory.listValue[i].type == Collectables.CollectableType.Potion){
				inventoryPotions.Add(playerInventory.listValue[i]);
			}
		}
		if(scrollUp){
			//Debug.Log("Index " + potIndex + " Count " + inventoryPotions.Count + " Item " + );
			potIndex++;
			if(inventoryPotions.Count == potIndex) potIndex = 0;
		}
		else{
			potIndex--;
			if(potIndex == 0) potIndex = inventoryPotions.Count-1;
		}
		selectedPotion.collectable = inventoryPotions[potIndex];

	}
	public void removeItem(){ //for later UI control

	}

	public void moveItem(){ //for later UI control

	}

}
