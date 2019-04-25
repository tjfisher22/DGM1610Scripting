using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitAI : MonoBehaviour {

	public Unit unit;
	public LayerMask unitLayer;
	public Transform unitCheck;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		unit.Think(this);
	}


	public bool IsNearEnemy(){//need to update
		Collider2D[] unitColliders = Physics2D.OverlapCircleAll(unitCheck.position, .5f, unitLayer);
		if(unitColliders.Length == 0){
			for (int i = 0; i< unitColliders.Length; i++){
					if(unitColliders[i].tag == "Player"){
						//melee attack
						//maybe do enum?
					}
					if(unitColliders[i].tag == "Enemy"){
						//Enemy near
					}
					//unitColliders[i].GetComponent<UnitControl>().TakeDamage(damage,gameObject.transform.localScale.x,weapon.knockbackTime);
				}
			return true;
		}
		else return false;
	}
}
