using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour {
	//Controls scense and handles player death

	public Unit player;
	public FloatListVariable playerHP;
	public GameObject playerObj;
	public Transform respawnPoint;
	public GameObject inventory;
	public int startingCoins = 10;
	public Collectables startingItem;

	void Start () {
		//Scene scene = SceneManager.GetActiveScene();
		playerHP.listValue[0]=player.maxHealth;
		inventory.GetComponent<InventoryManager>().playerInventory.listValue.Clear();
		inventory.GetComponent<InventoryManager>().playerInventory.listValue2.Clear();
		//give 10 coins 
		//gameObject.GetComponent<GameOverControl>().playerCoins.value = startingCoins; //Currently doesn't have intended effect. removed for now
		//maybe a few arrows
		inventory.GetComponent<InventoryManager>().AddItem(startingItem, startingItem.amount);
		//reset health
		playerHP.listValue[0]=player.maxHealth;
		player.jumpHeight = 17;
		player.maxHealth = 100;
		player.strength =20;
		player.defense = 10;
		player.speed =10;
		
		//StartGame();
	}
	void Update(){
		
	}
	
	public void RespawnPlayer(){
			playerObj.transform.position = respawnPoint.position;
			playerHP.listValue[0]=player.maxHealth;
			ShowPlayer();
			SceneManager.LoadScene("Game");
	}
	public void HidePlayer(){
		playerObj.GetComponent<SpriteRenderer>().enabled =false;
	}
	public void ShowPlayer(){
		playerObj.GetComponent<SpriteRenderer>().enabled =true;
	}
	public void StartGame(){
		//for(int i = 0; )
		//clear inventory
	
		// inventory.GetComponent<InventoryManager>().playerInventory.listValue.Clear();
		// inventory.GetComponent<InventoryManager>().playerInventory.listValue2.Clear();
		// //give 10 coins 
		// gameObject.GetComponent<GameOverControl>().playerCoins.value = startingCoins;
		// //maybe a few arrows
		// inventory.GetComponent<InventoryManager>().AddItem(startingItem, startingItem.amount);
		// //reset health
		// playerHP.listValue[0]=player.maxHealth;
		RespawnPlayer();
	}

}
