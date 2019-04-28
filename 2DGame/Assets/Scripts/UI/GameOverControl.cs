using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverControl : MonoBehaviour {
	GameObject[] deathObjects;
	public Text continueCoins;
	public FloatVariable coinsRequired;
	public FloatVariable playerCoins;
	FloatListVariable playerHP;

	public StringListVariable highscores;

	public int coinIncrease = 10;

	// Use this for initialization
	void Start () {
		playerHP = gameObject.GetComponent<GameManager>().playerHP;
		Time.timeScale = 1;
		deathObjects = GameObject.FindGameObjectsWithTag("ShowOnDie");
		continueCoins.text = coinsRequired.value.ToString();	
		HideGameOver();
	}
	
	// Update is called once per frame
	void Update () {
		if(playerHP.listValue[0]<=0){
			Time.timeScale = 0;
			gameObject.GetComponent<GameManager>().HidePlayer();
			ShowGameOver();
		}
	}

	void ShowGameOver(){
		foreach(GameObject obj in deathObjects){
			obj.SetActive(true);
		}
	}

	//hides objects with ShowOnFinish tag
	void HideGameOver(){
		foreach(GameObject obj in deathObjects){
			obj.SetActive(false);
		}
	}
	public void Contine(){
		if(playerCoins.value>coinsRequired.value;){
			Time.timeScale = 1;
			gameObject.GetComponent<GameManager>().RespawnPlayer();
			playerCoins.value -= coinsRequired.value;
			coinsRequired.value += coinIncrease;
		}
		else{
			Debug.Log("No money?");//change this to an actual UI thing later
			GiveScore();
		}
		//color button red if not enough coins?
	}
	public void FreshStart(){
		Time.timeScale = 1;
		gameObject.GetComponent<GameManager>().StartGame();
	}

	public void GiveScore(){
		//popup box for name;
		string name = "Joe";
		highscores.listValue.Add(name);
		highscores.listValue2.Add(playerCoins.value);
		Debug.Log("Congrats, you got " + playerCoins.value +" coins for your retirement");//change this to an actual UI thing later

	}
}
