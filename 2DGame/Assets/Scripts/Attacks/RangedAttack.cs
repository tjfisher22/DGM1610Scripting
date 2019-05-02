using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : MonoBehaviour {
	//Ranged attack control
	//not currently implemented
	public Unit unit;
	public Bow bow;
	public Transform arrow;
	float chargeTime;
	public Transform Spawnpoint;
	void Start () {
		
	}
	void Update () {
		FireBow();
	}


	public void FireBow(){
		if(Input.GetButtonDown("Fire1")){
			chargeTime = 0;
			StartCoroutine(ChargeBow());
		}
		if(Input.GetButtonUp("Fire1")){
			Transform clone;
			clone = Instantiate(arrow, Spawnpoint.position, arrow.rotation);

			clone.GetComponent<Rigidbody2D>().velocity = Spawnpoint.TransformDirection (Vector2.right*20);
		}

	}

	IEnumerator ChargeBow(){


		while (Input.GetButton("Fire1")){
			if(chargeTime<bow.timeToFull*4)chargeTime++;
			else chargeTime = bow.timeToFull*4;
		//use multiple states for bow animation
			yield return new WaitForSeconds(.25f);
		}

		//yield return new WaitForSeconds(3f);

		
	}
}
