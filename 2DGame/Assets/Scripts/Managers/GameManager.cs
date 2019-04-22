using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public Unit player;
	public HPListVariable playerHP;
	public GameObject playerObj;
	public Transform respawnPoint;




	// Use this for initialization
	void Start () {
		//Scene scene = SceneManager.GetActiveScene();
	}
	
	// Update is called once per frame
	void Update () {
		RespawnPlayer();
	}

	void RespawnPlayer(){
		if(playerHP.listValue[0]<=0){
			//reload scene?
			playerObj.transform.position = respawnPoint.position;
			playerHP.listValue[0]=player.maxHealth;
			SceneManager.LoadScene("Game");
		}

	}
}
