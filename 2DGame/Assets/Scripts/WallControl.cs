using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallControl : MonoBehaviour {
	//adds knockback when player hits wall to prevent getting stuck to the side

	public float knockbackDirection;
	//public LayerMask layersToKnockBack;
	void OnCollisionEnter2D(Collision2D other){
		if(other.gameObject.tag == "Player" || other.gameObject.tag == "Enemy"){
			other.gameObject.GetComponent<UnitControl>().TakeDamage(0,knockbackDirection,.75f);
		}
	}
}
