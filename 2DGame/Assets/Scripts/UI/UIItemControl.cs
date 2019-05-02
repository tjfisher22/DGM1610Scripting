using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIItemControl : MonoBehaviour {

	public CollectVariable selectedItem;
	public Inventory playerInventory;
	public FloatVariable playerCoins;
	public Text count;
	public Text name;
	public Text coins;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		coins.text = playerCoins.value.ToString();
		//make it so when fire1 is pressed, selectedItem switches to SelectedArrow and then back to selectedPotion when released
		gameObject.GetComponent<Image>().color = selectedItem.collectable.color;
		//Scrolling item display
		if(playerInventory.listValue.Contains(selectedItem.collectable)){//find if item is in list
			int inventoryIndex = playerInventory.listValue.FindIndex(x => x.Equals(selectedItem.collectable));//if so find it's index
			count.text = playerInventory.listValue2[inventoryIndex].ToString();
			name.text = playerInventory.listValue[inventoryIndex].name;
		}
		else
		{
			name.text = "";
			count.text = 0.ToString();
		}
		
	}
}
