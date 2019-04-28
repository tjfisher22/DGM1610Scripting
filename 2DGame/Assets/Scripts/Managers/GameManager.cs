using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public Unit player;
	public FloatListVariable playerHP;
	public GameObject playerObj;
	public Transform respawnPoint;
	public GameObject inventory;




	// Use this for initialization
	void Start () {
		//Scene scene = SceneManager.GetActiveScene();
	}
	
	// Update is called once per frame
	void LateUpdate () {
		RespawnPlayer();
	}

	void RespawnPlayer(){
		if(playerHP.listValue[0]<=0){
			playerObj.transform.position = respawnPoint.position;
			playerHP.listValue[0]=player.maxHealth;
			SceneManager.LoadScene("Game");
		
			//StartCoroutine(WaitForRespawn());
		}
	}
	// IEnumerator WaitForRespawn(){

	// 		//yield return new WaitForSeconds(3f);//inventory.GetComponent<PotionControl>()usedPotion.duration);
	// 		//reload scene?
	// 		playerObj.transform.position = respawnPoint.position;
	// 		playerHP.listValue[0]=player.maxHealth;
	// 		SceneManager.LoadScene("Game");
		
	// }
}
