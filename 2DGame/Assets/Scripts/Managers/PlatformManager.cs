using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour {

	public GameObject enemyMng;
	[Range(0.0f,1.0f)]
	public float enemySpawnChance = .5f; //SO might be better for development

    public int maxPlatforms = 20;
    public GameObject platform;
	public GameObject death;
    public float horizontalMin = 7.5f;
    public float horizontalMax = 14f;
    public float verticalMin = -6f;
    public float verticalMax = 6;
	[HideInInspector]
	public Vector2 randomPosition;

	private Vector2 originPosition;

	// Use this for initialization
	void Start () {
		originPosition = transform.position;
		Spawn();
	}
	
	// Update is called once per frame
	void Update () {
	}

	void Spawn(){
		for (int i = 0; i < maxPlatforms; i++) {
            randomPosition = originPosition + new Vector2 (Random.Range(horizontalMin, horizontalMax), Random.Range (verticalMin, verticalMax));
            Instantiate(platform, randomPosition, Quaternion.identity);
			Instantiate(death, new Vector2(randomPosition.x,death.transform.position.y),Quaternion.identity);
            originPosition = randomPosition;
			if(Random.Range(0.0f,1.0f)<enemySpawnChance){
				enemyMng.GetComponent<EnemyManager>().SpawnEnemy(new Vector2(originPosition.x+Random.Range(-3,3),originPosition.y+Random.Range(3,6)));
			}
        }
	}
}
