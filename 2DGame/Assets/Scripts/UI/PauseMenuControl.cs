using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PauseMenuControl : MonoBehaviour {
	GameObject[] pauseObjects;
	// Use this for initialization
	void Start () {
		Time.timeScale = 1;
		pauseObjects = GameObject.FindGameObjectsWithTag("ShowOnPause");
		HidePaused();
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			Debug.Log("Test");
			if(Time.timeScale == 1)
			{
				Time.timeScale = 0;
				ShowPaused();
			} else if (Time.timeScale == 0){
				Time.timeScale = 1;
				HidePaused();
			}
		}
	}
	public void PauseControl(){
			if(Time.timeScale == 1)
			{
				Time.timeScale = 0;
				ShowPaused();
			} else if (Time.timeScale == 0){
				Time.timeScale = 1;
				HidePaused();
			}
	}
	public void Reload(){
		//use the script you'll put in gamemanager for starting the game
		//Application.LoadLevel(Application.loadedLevel);
	}

	public void ShowPaused(){
		foreach(GameObject obj in pauseObjects){
			obj.SetActive(true);
		}
	}

	public void HidePaused(){
		foreach(GameObject obj in pauseObjects){
			obj.SetActive(false);
		}
	}
	public void LoadScene(string level){
		SceneManager.LoadScene(level);
	}
}
