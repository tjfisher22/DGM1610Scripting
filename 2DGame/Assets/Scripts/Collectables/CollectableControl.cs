using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Collect(CollectableAI pickUp){

		//destroy object

		


	}

	void OnTriggerEnter2D(Collider2D other){
		Debug.Log(other);
	}
}
