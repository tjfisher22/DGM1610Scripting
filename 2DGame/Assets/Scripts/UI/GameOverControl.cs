using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverControl : MonoBehaviour {
	GameObject[] deathObjects;
	public Text continueCoins;
	public FloatVariable coinsRequired;
	public StringListVariable highscores;
	FloatListVariable playerHP;

	// Use this for initialization
	void Start () {
		playerHP = gameObject.GetComponent<GameManager>().playerHP;
		Time.timeScale = 1;
		deathObjects = GameObject.FindGameObjectsWithTag("ShowOnDie");
		continueCoins.text = coinsRequired.ToString();	
		HideGameOver();
	}
	
	// Update is called once per frame
	void Update () {
		if(playerHP.listValue[0]<=0){
			Time.timeScale = 0;
			ShowGameOver();
		}
	}

	public void ShowGameOver(){
		foreach(GameObject obj in deathObjects){
			obj.SetActive(true);
		}
	}

	//hides objects with ShowOnFinish tag
	public void HideGameOver(){
		foreach(GameObject obj in deathObjects){
			obj.SetActive(false);
		}
	}
}
