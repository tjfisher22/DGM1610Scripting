using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New CollectVar", menuName = "Variable/Collectable")]
public class CollectVariable : ScriptableObject {

	public string description;
	public Collectables collectable;
}
