using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using System.Linq;

public class EnemyManager : MonoBehaviour {

	public HPListVariable enemyHPs;
	public UnitListVariable enemyTypes;
	public Transform enemyPrefab;
	public Transform collectPrefab;

	private int toSpawnID;
	private CollectListVariable drops;
	private List<GameObject> objList = new List<GameObject>();
	private int enemyNumber;
	


	// Use this for initialization
	void Start () {
		enemyHPs.listValue.Clear();
		enemyNumber = 0;
		
	}
	
	// Update is called once per frame
	void Update () {
		// SpawnEnemy(new Vector2(0,10));
		KillEnemy();

		
	}

	public void SpawnEnemy (Vector2 position) {
		// if(Input.GetButtonDown("Jump")){
			GameObject obj;
			int rngEnemy = Random.Range(0,enemyTypes.listValue.Count);
			Debug.Log("enemy Rng" + rngEnemy);
			obj = Instantiate(enemyPrefab, position, Quaternion.identity).gameObject;
			obj.GetComponent<UnitControl>().unit = enemyTypes.listValue[rngEnemy];
			obj.GetComponent<UnitAI>().unit = enemyTypes.listValue[rngEnemy];
			//Debug.Log(obj);
			enemyHPs.listValue.Add(enemyPrefab.gameObject.GetComponent<UnitControl>().unit.maxHealth);
			//Debug.Log((enemyPrefab.gameObject.GetComponent<UnitControl>().unit.maxHealth));
			obj.GetComponent<UnitControl>().unitID = enemyNumber;
			objList.Add(obj);
			enemyNumber++;
			Debug.Log("EnemSpawn");
		
		//addsome randomness to the enemy as well maybe?

		

	}

	//Should probably move spawn enemy to seperate class for
	//code management but it'll be small enough for this project
	void DropCollectables (GameObject enemy) {
		Transform pickUp;
		bool spawning = true;
		int spawnCount = 0;
		float rng;
		Vector2 spawnPoint;
		drops = enemy.GetComponent<UnitControl>().collectsToDrop;
		for(int i = 0; i<drops.listValue.Count; i++){
			while(spawning){
				rng = Random.Range(0.0f,1.0f);
				//Debug.Log(drops.listValue[i] + "Random num:" + rng + "Chance" + (drops.listValue2[i]-spawnCount));
				
				if(rng<drops.listValue2[i]-spawnCount){
					spawnPoint = new Vector2(enemy.transform.position.x+rng, enemy.transform.position.y+rng);
					pickUp = Instantiate(collectPrefab, spawnPoint, enemy.transform.rotation);
					toSpawnID = pickUp.GetComponent<CollectableControl>().possiblePickUps.listValue.IndexOf(drops.listValue[i]);
					pickUp.GetComponent<CollectableControl>().pickUpID = toSpawnID;
					spawnCount++;
					if(spawnCount>drops.listValue2[i]) spawning = false;
				}
				else spawning = false;
			}
			spawning = true;
			spawnCount = 0;
		}
		

		
	}
	

	void KillEnemy () {
		GameObject deadObj;
        for (int i = enemyHPs.listValue.Count - 1; i >=0 ; i--){//This might be better as a call from unitControl, to keep the loops down but this keeps it more OOP so???
			if(enemyHPs.listValue[i] == 0){
				if(objList[i]!=null){
					deadObj = objList[i];
					DropCollectables(deadObj);
					Destroy(deadObj);
					//objList.Remove(deadObj);
					// return i;
				}
			}
		}
	}
}
