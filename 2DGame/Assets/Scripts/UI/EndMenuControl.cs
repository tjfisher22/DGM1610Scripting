using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndMenuControl : MonoBehaviour {
	//Control for the final scene
	public StringListVariable highscores;
	public FloatVariable playerCoins;
	public Text congrats;
	public InputField HSName;
	public Button mainMenu;
	void Start () {
		congrats.text = "Congrats! You ended with " + playerCoins.value + " coins!";
	}
	
	// Update is called once per frame
	void Update () {

		
	}

	public void TakeScore(){
		highscores.listValue.Add(HSName.text);
		highscores.listValue2.Add(playerCoins.value);
		SceneManager.LoadScene("MainMenu");
	}
}
