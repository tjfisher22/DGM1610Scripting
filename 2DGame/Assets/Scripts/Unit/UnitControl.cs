using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitControl : MonoBehaviour {

	public Unit unit;
	public int unitID;
	//[HideInInspector]
	public int unitDirMod = 1;

	public FloatListVariable currentHP;
	public CollectListVariable collectsToDrop;
	public float knockbackXMod = 1;
	public float knockbackYMod = 1;
	public float knockbackTimeMod = 1;

	//public int currentHealth;
	
	//float jumpHeight;
	float speed;
	float sneakMod;
	float sprintMod;

	float rightDirect;

	float movementInputValue;
	bool sneakInput;
	bool sprintInput;

	bool inKnockback;
	//float knockbackTime = 1.5f; //add this to unit data
	[HideInInspector]
	public bool nearEdge;
	[HideInInspector]
	public float distance = 2f;


	private Animator unitAnim;
	private Rigidbody2D unitBody;
	private SpriteRenderer unitSprite;
	public LayerMask groundLayer;
	public LayerMask unitLayer;
	public Transform edgeCheck;
	public Transform unitCheck;

	// Use this for initialization
	void Start () {
		unitAnim = gameObject.GetComponent<Animator> ();
		unitBody = gameObject.GetComponent<Rigidbody2D> ();
		unitSprite = gameObject.GetComponent<SpriteRenderer> ();
		collectsToDrop = unit.collectsToDrop;

		unitSprite.color = unit.unitColor;
		rightDirect = transform.localScale.x;

	}
	

	void FixedUpdate () {
		Walk();
		TooLow();
		IsFalling();
		//IsNearEnemy();
	}

	public bool IsEdge(float speed){
		//use speed to modify sphere radius
		Collider2D[] platformColliders = Physics2D.OverlapCircleAll(edgeCheck.position, .5f, groundLayer);
		if(platformColliders.Length == 0){
			return true;
		}
		else return false;
	}
	public void TakeDamage(float damage, float dir, float kbStr){//This should probably get moved to a manager, because right now it passes from MeleeAttacks to Enemy Manager
										//but becasue I have this baked into the player I'd also have to create a manager for the player
										//If I have time I'll change it up. For now, this should do.
		if(currentHP!= null){
			float dmg = damage;
			currentHP.listValue[unitID] -= ((dmg>unit.defense) ? dmg-unit.defense:0);
			//Debug.Log(unit.name + "Took Damage");
			StartCoroutine(Knockback(dir,kbStr));
			if(currentHP.listValue[unitID] <=0){
				currentHP.listValue[unitID] = 0;
				// Debug.Log(unit.name+" Died");
				// this.gameObject.SetActive(false);
			}
		}
		else{
			
		}
	}
	public void Control(float unitMovement, bool sneak, bool sprint){
		movementInputValue = unitMovement;
		sneakInput = sneak;
		sprintInput = sprint;

	}
	void Walk(){
		if(inKnockback){return;}
		float moveSpeed = movementInputValue*unit.speed;
		float sneakSpeed = moveSpeed*unit.sneakModifier;
		float sprintSpeed = moveSpeed*unit.sprintModifier;
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
		unitSpeed *= unitDirMod;

		//Move the unit
		unitBody.velocity = new Vector2(unitSpeed,unitBody.velocity.y);

		//Determine what animation to play
		unitAnim.SetFloat("speed", Mathf.Abs(unitSpeed));

		//change to mouse controls? and move slower backwards?
		if(unitSpeed<0){ 
			gameObject.transform.localScale = new Vector2(-rightDirect,transform.localScale.y);
		}
		if(unitSpeed>0){ 	
			gameObject.transform.localScale = new Vector2(rightDirect,transform.localScale.y);
		}
	}

	//Jump() and IsGrounded() could be moved to another script to provide access to other entities potentially
	public void Jump(){
		float jump = unit.jumpHeight;
			if(IsFalling()){return;}
			unitBody.velocity = new Vector2(unitBody.velocity.x,jump);
			//play jump animation here
			//unitAnim.Play("Jump");

	}

	public IEnumerator Knockback(float kbDir, float kbStr){
		inKnockback = true;
		Debug.Log("KnockBack");
		//gameObject.transform.localScale = new Vector2(-kbDir,transform.localScale.y);
		unitBody.AddForce(new Vector2(kbDir*kbStr*knockbackXMod, kbStr*knockbackYMod)*1750f);
		yield return new WaitForSeconds(kbStr*knockbackTimeMod);
		inKnockback = false;
	}

	bool IsGrounded() {
    	Vector2 position = transform.position;
		
    	Vector2 direction = new Vector2(0,-1*distance);
    	
    
        Debug.DrawRay(position, direction, Color.green);
		//Apparently raycasting is bad for optimization, probably should change it to a child gameobject
		RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, groundLayer); 
    	if (hit.collider != null) {
        	return true;
    	}
    
    return false;
	}

	public bool IsFalling() {
		if(IsGrounded()) {
			//add falling animation here
			//unitAnim.SetLayerWeight (unitAnim.GetLayerIndex ("Air Movement"), 0);
			unitAnim.SetBool("falling", false);
			//Debug.Log("Not Falling");
			return false;
		}
		else {
			//unitAnim.SetLayerWeight (unitAnim.GetLayerIndex ("Air Movement"), 2);
			unitAnim.SetBool("falling", true);
			//Debug.Log("Falling");
			return true;
		}
	}
//move to IEnumerator since tooLow doesn't need to be checked every frame
	void TooLow(){
		if(gameObject.transform.position.y < -100){
			currentHP.listValue[unitID] = 0;
		}
	}

	void OnCollisionEnter2D(Collision2D other){
		//Debug.Log(other.gameObject.layer);
		if(other.gameObject.layer==LayerMask.NameToLayer("Death")){
			currentHP.listValue[unitID] = 0;
		}
	}

	

}