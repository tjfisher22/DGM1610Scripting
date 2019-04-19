using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

	public FloatVariable enemyHPs;
	public FloatVariable enemyNum;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		SpawnEnemy();
		
	}

	void SpawnEnemy () {
		if(Input.GetButtonDown("Melee")){
			//enemyHPs.listValue.add(2f);
		}
		

	}

	//Should probably move spawn enemy to seperate class for
	//code management but it'll be small enough for this project
	void DropCollectables (GameObject enemy, SpawnRates rates ) {

	}

	void KillEnemy (GameObject enemy, int damage, int enemyNumber) {
		
	}
}
