using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeControl : MonoBehaviour {
	//Control for melee attacks
	//Mostly weapon data and trigger events
	public Unit unit;
	public Weapon weapon;
	private SpriteRenderer weaponSprite;
	//public string enemyTag;

	void Start () {
		weaponSprite = gameObject.GetComponent<SpriteRenderer> ();
		weaponSprite.sprite = weapon.sprite;
		//weaponSprite.color = weapon.color; Changed to just match the units color but can be reverted if more control is wanted. 
		weaponSprite.color = unit.unitColor;
		weaponSprite.sortingOrder = 100;
		
	}
	void OnTriggerEnter2D(Collider2D other){ 
		if(other.gameObject.tag == unit.enemyTag){
			other.gameObject.GetComponent<UnitControl>().TakeDamage(weapon.damage+unit.strength,this.transform.parent.gameObject.transform.localScale.x,weapon.knockBack);
		}
	}
}
