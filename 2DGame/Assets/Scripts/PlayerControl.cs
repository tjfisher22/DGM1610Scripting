﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

	public Unit player;



	float jumpHeight;
	float speed;
	float sneakMod;
	float sprintMod;

	float rightDirect;
		

	// bool hasDoubleJump = false;
	//bool grounded = false;


	private Animator playerAnim;
	private Rigidbody2D playerBody;
	private SpriteRenderer playerSprite;
	public LayerMask groundLayer;

	// Use this for initialization
	void Start () {
		speed = player.speed;
		sneakMod = player.sneakModifier;
		sprintMod = player.sprintModifier;
		jumpHeight = player.jumpHeight;
		playerAnim = gameObject.GetComponent<Animator> ();
		playerBody = gameObject.GetComponent<Rigidbody2D> ();
		playerSprite = gameObject.GetComponent<SpriteRenderer> ();

		rightDirect = transform.localScale.x;

	}
	
	// Update is called once per frame
	void Update () {
		Walk();
		Jump();
		
	}

	void Walk(){
		float moveSpeed = Input.GetAxis("Horizontal")*speed;
		float sneakSpeed = moveSpeed*sneakMod;
		float sprintSpeed = moveSpeed*sprintMod;
		float playerSpeed;



		//apparently switch statments don't work with inputs so ifelse it is
		//Determine which movement speed and animation cycle should be applied
		if(Input.GetButton("Sneak")){ //I have this set to leftctrl right now but unity interferes with it
										//as in when pressing ctrl + D to sneak right, unity thinks you're trying to dupllicate the object
										//Works with the alternate mouse3 though
			playerSpeed = sneakSpeed;

		}
		else if(Input.GetButton("Sprint")){
			playerSpeed = sprintSpeed;
		}
		else {
			playerSpeed = moveSpeed;
		}

		//Move the player
		playerBody.velocity = new Vector2(playerSpeed,playerBody.velocity.y);

		//Determine what animation to play
		playerAnim.SetFloat("speed", Mathf.Abs(playerSpeed));
		bool right = true;
		if(playerSpeed<0&&right){ 
			//playerSprite.flipX = true;
			gameObject.transform.localScale = new Vector2(-rightDirect,transform.localScale.y);
		 	right = false;
			
		}
		if(playerSpeed!=0) return;
		else//(playerSpeed>0&&!right){ //I don't know why this didn't work with the conditions provided but addign the if makes it work
		//nevermind
			{
			//playerSprite.flipX = false;
			gameObject.transform.localScale = new Vector2(rightDirect,transform.localScale.y);
			right = true;
			
		}
		
			



		


		//Should animations be moved to their own script?
		//No, because it can all be done in the animator controller!!! :)
		
	// 	if (moveSpeed!=0) { // doesn't account for deadzones on controller but should be fine for now //also, you can change zones in input manager?
	// 		if(walkCycling==false){
    //     		playerAnim.Play(cycleType, 0, 0.6f);//could use gamepad values to change speed but not needed for this class
	// 			walkCycling = true;
	// 		}
	// 		else if(walkCycling)
	// 			playerAnim.Play(cycleType);

	// 	} 
    // 	else {
	// 		if(!jumping){
    // 			playerAnim.Play("Idle");
	// 			walkCycling = false;
	// 		}
	// 	}
}

	//Jump() and IsGrounded() could be moved to another script to provide access to other entities potentially
	void Jump(){
		if(!IsGrounded()){return;}
		float jump = Input.GetAxisRaw("Jump")*jumpHeight;
		if(Input.GetButton("Jump")){
			playerBody.velocity = new Vector2(playerBody.velocity.x,jump);
			//grounded=false;
			//play jump animation here
			playerAnim.Play("Jump");
		}

	}

	bool IsGrounded() {
    	Vector2 position = transform.position;
		float distance = 2f;
    	Vector2 direction = new Vector2(0,-1*distance);
    	
    
        Debug.DrawRay(position, direction, Color.green);
    	RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, groundLayer);
    	if (hit.collider != null) {
        	return true;
    	}
    
    return false;
	}

	//combining in Walk() with 
	// void Sneak (){
	// 	float sneakSpeed = Input.GetAxisRaw("Sneak")*speed/2;
	// 	if(sneakSpeed!=0){
	// 		playerBody.velocity = new Vector2(sneakSpeed,playerBody.velocity.y);
	// 		if(walkCycling==false){
    //     		playerAnim.Play("Walk Cycle", 0, 0.6f);//change to sneak
	// 			walkCycling = true;
	// 		}
	// 		else if(walkCycling)
	// 			playerAnim.Play("Walk Cycle");//change to sneak
	// 		if(moveSpeed<0)playerSprite.flipX = true;
	// 		else playerSprite.flipX = false;
	// 	}
    // 	else {
    // 		playerAnim.Play("Idle");
	// 		walkCycling = false;
	// 	}


	// }
}
