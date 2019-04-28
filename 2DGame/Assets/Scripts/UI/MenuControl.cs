using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MenuControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButton(0)){//still returns one null reference but it's better than before
			if(EventSystem.current.currentSelectedGameObject.name == "StartButton"){
		 		SceneManager.LoadScene(1);
			}
			if(EventSystem.current.currentSelectedGameObject.name == "QuitButton"){
		 		Application.Quit();
			}
		}
	}
}
