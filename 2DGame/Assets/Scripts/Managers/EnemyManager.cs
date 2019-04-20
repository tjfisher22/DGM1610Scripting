using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

	public HPListVariable enemyHPs;
	public Transform enemyPrefab;
	public int enemyNumber;


	// Use this for initialization
	void Start () {
		enemyHPs.listValue.Clear();
		
	}
	
	// Update is called once per frame
	void Update () {
		SpawnEnemy(new Vector2(0,10));
		
	}

	void SpawnEnemy (Vector2 position) {
		if(Input.GetButtonDown("Jump")){
			GameObject obj;
			obj = Instantiate(enemyPrefab, position, Quaternion.identity).gameObject;
			//Debug.Log(obj);
			enemyHPs.listValue.Add(enemyPrefab.gameObject.GetComponent<UnitControl>().unit.maxHealth);
			obj.GetComponent<UnitControl>().unitID = enemyNumber;
			enemyNumber++;
			
			//create list of transforms with new objects put in

		}
		

	}

	//Should probably move spawn enemy to seperate class for
	//code management but it'll be small enough for this project
	void DropCollectables (GameObject enemy, CollectVariable rates ) {
		
	}

	void DamageEnemy (GameObject enemy, int damage, int enemyNumber) {
		
	}
}
