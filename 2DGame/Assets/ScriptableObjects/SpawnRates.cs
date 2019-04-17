using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New SpawnRate", menuName = "Collectables/Spawn Rate")]
public class SpawnRates : ScriptableObject {
	public Collectables[] items;
	public float[] spawnRate;

// wait, Creating a 2d array won't work because they are different times
// 	//public List<List<Collectables>> colList = new List<List<Collectables>>();
// 	public Collectables[] items;
// 	// public float[] items;
// 	// public float[] spawnRate{
// 	// 	get items;
// 	// }	
// }
// [System.Serializable]
// class items{
// 		public float[] spawnRate = new items[4];
}