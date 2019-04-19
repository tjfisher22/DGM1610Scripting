﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject player;

	private Vector3 offset;

	// Use this for initialization
	void Start () {
		offset = transform.position - player.transform.position;
		
	}
	
	// Update is called once per frame
	void LateUpdate () {

		transform.position = new Vector3(player.transform.position.x + offset.x,transform.position.y,transform.position.z);
		
	}
}