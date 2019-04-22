using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New List", menuName = "Variable/Unit List")]
public class UnitListVariable : ListVariable<Unit, float> {//float so I can individually adjust spawn chances
}
