using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// [System.Serializable]
public  class ListVariable<T,Y> : ScriptableObject {

	public string description;
	public float value;
	
	public List<T> listValue = new List<T>();
	public void Add(T t){
		if(!listValue.Contains(t)) listValue.Add(t);
	}
	public void Remove(T t){
		if(listValue.Contains(t)) listValue.Remove(t);
	}
	//HOLY CoW?
	//I can't believe this worked on my first try, but it fixes
	//issues I was having with spawn rates so that's a plus. 
	public List<Y> listValue2 = new List<Y>();
	public void Add(Y y){
		if(!listValue2.Contains(y)) listValue2.Add(y);
	}
	public void Remove(Y y){
		if(listValue2.Contains(y)) listValue2.Remove(y);
	}

}

//Should be an overload function for when listVariable is only passed on thing
//allows for one dimensional lists as well
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
}
		
