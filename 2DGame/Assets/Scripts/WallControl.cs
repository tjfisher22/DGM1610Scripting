using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallControl : MonoBehaviour {

	public float knockbackDirection;
	//public LayerMask layersToKnockBack;
	void OnCollisionEnter2D(Collision2D other){
		//Debug.Log(other.gameObject);
		//Debug.Log("Layer Name" + LayerMask.LayerToName(layersToKnockBack));
		if(other.gameObject.tag == "Player" || other.gameObject.tag == "Enemy"){
			Debug.Log("Worked");
			other.gameObject.GetComponent<UnitControl>().TakeDamage(0,knockbackDirection,1.5f);
		}
	}
}
