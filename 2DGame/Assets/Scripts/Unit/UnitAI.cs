using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitAI : MonoBehaviour {
	public enum NearbyUnitType {None, Enemy, Player};

	public Unit unit;
	public LayerMask unitCheckLayer;
	public Transform unitCheck;
	[HideInInspector]
	public NearbyUnitType nearUnit;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		unit.Think(this);
	}


	public NearbyUnitType FacingUnit(){
		Collider2D[] unitColliders = Physics2D.OverlapCircleAll(unitCheck.position, .5f, unitCheckLayer);
		if(unitColliders.Length != 0){
			for (int i = 0; i< unitColliders.Length; i++){
					if(unitColliders[i].tag == "Player"){
						nearUnit = NearbyUnitType.Player;
						break;//break out of for loop since the player is most important
						//as in if there is a player and an enemy I want them to focus on the player
					}
					if(unitColliders[i].tag == "Enemy"){
						nearUnit = NearbyUnitType.Enemy;
					}
				}			
		}
		else {nearUnit = NearbyUnitType.None;}
		return nearUnit;
	}
	
}
