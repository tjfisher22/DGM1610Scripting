using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableAI : MonoBehaviour {

	//Base control for Collectables
	public Collectables pickUp;
	[HideInInspector]
	public int pickUpID;
	[HideInInspector]
	public CollectListVariable possiblePickUps;
	
	void Start () {
		//pickUpID is given a value from the spawn manager. This class then matches this with the possiblePickUps list to determine what pickUp it should be.
		pickUp = possiblePickUps.listValue[pickUpID];
	}
	
	
	void Update () {
		//call to relavant Scriptable Object class
		pickUp.Collect(this);
	}

}
