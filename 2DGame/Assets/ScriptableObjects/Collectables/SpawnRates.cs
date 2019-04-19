using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//  [System.Serializable]
//  public struct spawnRate
//  {
//      //public string name;
// 	 public float rate;
// 	 public int number;
//      public List<CollectableData> collect;
//  }
 
//  [System.Serializable]
//  public struct CollectableData
//  {
// 	 public string name;
// 	 public Collectables item;


//  }

[CreateAssetMenu(fileName = "New SpawnRate", menuName = "Collectables/Spawn Rate")]
public class SpawnRates : ScriptableObject {
	public string name;

	// public List<spawnRate> Rates = new List<spawnRate>();

	// public void _SpawnRates (){
	// 	spawnRate first = new spawnRate();

	// 	first.rate = .1f;
	// 	first.number = 2;


	// 	first.collect = new List<Collectables>();

	// 	CollectableData test = new CollectableData();
	// }


	// public Collectables[] items = new Collectables[3];
	// public float[] spawnRate= new float[3];
	// public int[] number= new int[3];


// lists not showing in inspector

	public ListVariable<Collectables> items;
	public ListVariable<float> rates;
	public ListVariable<int> number;


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