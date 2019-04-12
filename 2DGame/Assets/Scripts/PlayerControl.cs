using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

	public Unit player;

	public float jumpHeight;
	public float speed;
	
	

	// bool hasDoubleJump = false;
	//bool grounded = false;
	bool walkCycling = false;

	private Animator playerAnim;
	private Rigidbody2D playerBody;
	private SpriteRenderer playerSprite;
	public LayerMask groundLayer;

	// Use this for initialization
	void Start () {
		speed = player.speed;
		jumpHeight = player.jumpHeight;
		playerAnim = gameObject.GetComponent<Animator> ();
		playerBody = gameObject.GetComponent<Rigidbody2D> ();
		playerSprite = gameObject.GetComponent<SpriteRenderer> ();

	}
	
	// Update is called once per frame
	void Update () {
		Walk();
		Jump();
		Sneak();
	}

	void Walk(){
		float moveSpeed = Input.GetAxis("Horizontal")*speed;
		playerBody.velocity = new Vector2(moveSpeed,playerBody.velocity.y);

		//Should animations be moved to their own script?
		if (moveSpeed!=0) { // doesn't account for deadzones on controller but should be fine for now //also, you can change zones in input manager?
			if(walkCycling==false){
        		playerAnim.Play("Walk Cycle", 0, 0.6f);
				walkCycling = true;
			}
			else if(walkCycling)
				playerAnim.Play("Walk Cycle");
			if(moveSpeed<0)playerSprite.flipX = true;
			else playerSprite.flipX = false;
		}
    	else {
    		playerAnim.Play("Idle");
			walkCycling = false;
		}
	}

	//Jump() and IsGrounded() could be moved to another script to provide access to other entities
	void Jump(){
		if(!IsGrounded()){return;}
		float jump = Input.GetAxisRaw("Jump")*jumpHeight;
		if(jump>0){
			playerBody.velocity = new Vector2(playerBody.velocity.x,jump);
			//grounded=false;
			//play jump animation here
			//playerAnim.Play("Jump");
		}

	}

	bool IsGrounded() {
    	Vector2 position = transform.position;
		float distance = 1.75f;
    	Vector2 direction = new Vector2(0,-1*distance);
    	
    
        Debug.DrawRay(position, direction, Color.green);
    	RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, groundLayer);
    	if (hit.collider != null) {
        	return true;
    	}
    
    return false;
	}

	void Sneak (){
		float sneakSpeed = Input.GetAxisRaw("Sneak")*speed/2;
		if(sneakSpeed!=0){
			playerBody.velocity = new Vector2(sneakSpeed,playerBody.velocity.y);
			if(walkCycling==false){
        		playerAnim.Play("Walk Cycle", 0, 0.6f);//change to sneak
				walkCycling = true;
			}
			else if(walkCycling)
				playerAnim.Play("Walk Cycle");//change to sneak
			if(moveSpeed<0)playerSprite.flipX = true;
			else playerSprite.flipX = false;
		}
    	else {
    		playerAnim.Play("Idle");
			walkCycling = false;
		}
		}


	}
}
