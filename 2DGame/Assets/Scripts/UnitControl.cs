using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitControl : MonoBehaviour {

	public Unit unit;
	public FloatVariable currentHP;

	//public int currentHealth;
	
	float jumpHeight;
	float speed;
	float sneakMod;
	float sprintMod;

	float rightDirect;

	float movementInputValue;
	bool sneakInput;
	bool sprintInput;

	
		

	// bool hasDoubleJump = false;
	//bool grounded = false;
	public bool nearEdge;


	private Animator unitAnim;
	private Rigidbody2D unitBody;
	private SpriteRenderer unitSprite;
	public LayerMask groundLayer;
	public Transform edgeCheck;

	// Use this for initialization
	void Start () {
		
		// currentHealth = unit.maxHealth;
		speed = unit.speed;
		sneakMod = unit.sneakModifier;
		sprintMod = unit.sprintModifier;
		// jumpHeight = unit.jumpHeight;
		//putting these in start limits their usefullness as SOs


		unitAnim = gameObject.GetComponent<Animator> ();
		unitBody = gameObject.GetComponent<Rigidbody2D> ();
		unitSprite = gameObject.GetComponent<SpriteRenderer> ();

		unitSprite.color = unit.unitColor;
		Debug.Log(unit.unitColor);
		rightDirect = transform.localScale.x;

	}
	

	void FixedUpdate () {
		Walk();
		//EdgeCheck(.2f);//should this be in normal update()
		
	}

	public bool IsEdge(float speed){
		//use speed to modify sphere radius
		Collider2D[] platformColliders = Physics2D.OverlapCircleAll(edgeCheck.position, .5f, groundLayer);
		if(platformColliders.Length == 0){
			Debug.Log("Edge Detected");
			return true;
		}
		else return false;



	}

	public void TakeDamage(int damage){
		float dmg = (float)damage;
		currentHP.value -= dmg;

		if(currentHP.value <=0){
			currentHP.value = 0;
			Debug.Log(unit.name+" Died");
			this.gameObject.SetActive(false);
		}
	}
	public void Control(float unitMovement, bool sneak, bool sprint){
		movementInputValue = unitMovement;
		sneakInput = sneak;
		sprintInput = sprint;

	}
	void Walk(){
		float moveSpeed = movementInputValue*speed;
		float sneakSpeed = moveSpeed*sneakMod;
		float sprintSpeed = moveSpeed*sprintMod;
		float unitSpeed;

		//Determine which movement speed and animation cycle should be applied
		if(sneakInput){ 
			unitSpeed = sneakSpeed;

		}
		else if(sprintInput){
			unitSpeed = sprintSpeed;
		}
		else {
			unitSpeed = moveSpeed;
		}

		//Move the unit
		unitBody.velocity = new Vector2(unitSpeed,unitBody.velocity.y);

		//Determine what animation to play
		unitAnim.SetFloat("speed", Mathf.Abs(unitSpeed));

		//change to mouse controls? and move slower backwards?
		bool right = true;
		if(unitSpeed<0&&right){ 
			//unitSprite.flipX = true;
			gameObject.transform.localScale = new Vector2(-rightDirect,transform.localScale.y);
		 	right = false;
	
			
		}
		if(unitSpeed>0&&right){  //ok I have no clue why !right doesn't work but right does. Whatever
			//unitSprite.flipX = false;
			gameObject.transform.localScale = new Vector2(rightDirect,transform.localScale.y);
			right = true;
		}
	}

	//Jump() and IsGrounded() could be moved to another script to provide access to other entities potentially
	public void Jump(){
		float jump = unit.jumpHeight;
			if(!IsGrounded()){return;}
			unitBody.velocity = new Vector2(unitBody.velocity.x,jump);
			//grounded=false;
			//play jump animation here
			//unitAnim.Play("Jump");

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

	

}