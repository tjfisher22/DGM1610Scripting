using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Bow", menuName = "Weapon/Bow")]
public class Bow : Weapon {
	public float timeToFull;
	float accuracy;
	public float range;
}
