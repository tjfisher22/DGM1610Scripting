using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using System.Linq;

public class EnemyManager : MonoBehaviour {

	public HPListVariable enemyHPs;
	public Transform enemyPrefab;
	public Transform collectPrefab;

	private CollectVariable drops;
	private List<GameObject> objList = new List<GameObject>();
	private int enemyNumber;
	


	// Use this for initialization
	void Start () {
		enemyHPs.listValue.Clear();
		enemyNumber = 0;
		
	}
	
	// Update is called once per frame
	void Update () {
		SpawnEnemy(new Vector2(0,10));
		KillEnemy();

		
	}

	void SpawnEnemy (Vector2 position) {
		if(Input.GetButtonDown("Jump")){
			GameObject obj;
			obj = Instantiate(enemyPrefab, position, Quaternion.identity).gameObject;
			//Debug.Log(obj);
			enemyHPs.listValue.Add(enemyPrefab.gameObject.GetComponent<UnitControl>().unit.maxHealth);
			//Debug.Log((enemyPrefab.gameObject.GetComponent<UnitControl>().unit.maxHealth));
			obj.GetComponent<UnitControl>().unitID = enemyNumber;
			objList.Add(obj);
			enemyNumber++;
		}
		//addsome randomness to the enemy as well maybe?

		

	}

	//Should probably move spawn enemy to seperate class for
	//code management but it'll be small enough for this project
	void DropCollectables (GameObject enemy) {
		drops = enemy.GetComponent<UnitControl>().collectsToDrop;
		

		
	}

	void KillEnemy () {
		GameObject deadObj;
        for (int i = enemyHPs.listValue.Count - 1; i >=0 ; i--){
			if(enemyHPs.listValue[i] == 0){
				Debug.Log("i is" + i);
				deadObj = objList[i];
				DropCollectables(deadObj);
				Destroy(deadObj);
				//objList.Remove(deadObj);
				// return i;
			}
		}
	}
}
