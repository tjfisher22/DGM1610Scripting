using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeControl : MonoBehaviour {
	public Unit unit;
	public Weapon weapon;
	private SpriteRenderer weaponSprite;
	//public string enemyTag;

	void Start () {
		weaponSprite = gameObject.GetComponent<SpriteRenderer> ();
		weaponSprite.sprite = weapon.sprite;
		//weaponSprite.color = weapon.color;
		weaponSprite.color = unit.unitColor;
		weaponSprite.sortingOrder = 100;
		
	}
	void OnTriggerEnter2D(Collider2D other){ //this is broken
		//Debug.Log(other.gameObject);
		//Debug.Log("Layer Name" + LayerMask.LayerToName(layersToKnockBack));
		//should probable change this to a trigger enter
		if(other.gameObject.tag == unit.enemyTag){
			other.gameObject.GetComponent<UnitControl>().TakeDamage(weapon.damage+unit.strength,this.transform.parent.gameObject.transform.localScale.x,weapon.knockBack);
		}
	}
}
