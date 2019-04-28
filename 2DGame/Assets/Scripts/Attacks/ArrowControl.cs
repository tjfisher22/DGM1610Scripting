using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowControl : MonoBehaviour {
	public ArrowCollect arrow;
	private SpriteRenderer arrowSprite;

	void Start(){
		arrowSprite = gameObject.GetComponent<SpriteRenderer> ();
		arrowSprite.sprite = arrow.sprite;
		arrowSprite.color = arrow.color;
		arrowSprite.sortingOrder = 100;
		//change color of particle effect here
	}

	void OnCollisionEnter2D(Collision2D other){
		//Debug.Log(other.gameObject);
		//Debug.Log("Layer Name" + LayerMask.LayerToName(layersToKnockBack));
		if(other.gameObject.tag == "Player" || other.gameObject.tag == "Enemy"){
			//Debug.Log("Worked");
			other.gameObject.GetComponent<UnitControl>().TakeDamage(arrow.arrowDamage,-gameObject.transform.localScale.x,arrow.knockBack);
		}
	}
}
