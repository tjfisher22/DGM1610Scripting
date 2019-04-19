using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New List", menuName = "Variable/List")]
public  class ListVariable<T> : ScriptableObject {

	public string description;
	public float value;
	
	public List<T> listValue = new List<T>();
	public void Add(T t){
		if(!listValue.Contains(t)) listValue.Add(t);
	}
	public void Remove(T t){
		if(listValue.Contains(t)) listValue.Remove(t);
	}
	// [System.Serializable]
	// public struct ValueList{
	// 	[SerializeField]
	// 	private T _list;
	// }
}
		
