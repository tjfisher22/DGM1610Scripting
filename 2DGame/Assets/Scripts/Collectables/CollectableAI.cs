using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableAI : MonoBehaviour {

	public Collectables pickUp;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		pickUp.Collect(this);

	}

}
