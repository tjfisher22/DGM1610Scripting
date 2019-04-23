using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableAI : MonoBehaviour {

	public Collectables pickUp;
	[HideInInspector]
	public int pickUpID;
	[HideInInspector]
	public CollectListVariable possiblePickUps;
	// Use this for initialization
	void Start () {
		pickUp = possiblePickUps.listValue[pickUpID];
	}
	
	// Update is called once per frame
	void Update () {
		pickUp.Collect(this);

	}

}
