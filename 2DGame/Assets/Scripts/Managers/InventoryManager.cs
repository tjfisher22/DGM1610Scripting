using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour {

	public Inventory playerInventory;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void addItem(Collectables item, int amount){
		if(playerInventory.listValue.Contains(item)){//find if item is in list
			int inventoryIndex = playerInventory.listValue.FindIndex(x => x.Equals(item));//if so find it's index
			playerInventory.listValue2[inventoryIndex]+=amount;//and add to it's quantity
		}
		else{//if not 
			playerInventory.listValue.Add(item);//create new item slot  //limit max?
			playerInventory.listValue2.Add(amount);	//add quantity
		}

	}

	public void removeItem(){

	}

	public void moveItem(){

	}
}
