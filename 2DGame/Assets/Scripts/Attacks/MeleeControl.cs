using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeControl : MonoBehaviour {
	public Weapon weapon;
	private SpriteRenderer weaponSprite;

	void Start () {
		weaponSprite = gameObject.GetComponent<SpriteRenderer> ();
		weaponSprite.sprite = weapon.sprite;
		weaponSprite.color = weapon.color;
		weaponSprite.sortingOrder = 100;
		
	}
	void OnCollisionEnter2D(Collision2D other){
		//Debug.Log(other.gameObject);
		//Debug.Log("Layer Name" + LayerMask.LayerToName(layersToKnockBack));
		//should probable change this to a trigger enter
		if(other.gameObject.tag == "Player" || other.gameObject.tag == "Enemy"){
			Debug.Log("Worked");
			other.gameObject.GetComponent<UnitControl>().TakeDamage(weapon.damage,-gameObject.transform.localScale.x,weapon.knockBack);
		}
	}
}
