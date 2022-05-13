using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class NPC_Patrol : MonoBehaviour {
	private Animator anim;
	public bool patrolling = true;
	public float patrolDelay =1f;

	private GameHandler gameHandler;

	//patrol variables
	public float speed = 10f;
	private float waitTime;
	public float startWaitTime = 2f;

	public Transform[] moveSpots;
	private int nextSpot;
	private int previousSpot;
	public int startSpot = 0;
	public bool moveForward = true;
	public bool faceRight = false;
	

	void Start(){
		waitTime = startWaitTime;
		nextSpot = startSpot;

		anim = gameObject.GetComponentInChildren<Animator>();
		gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
	}

	void Update(){
	  if (patrolling == true){
		
		transform.position = Vector2.MoveTowards(transform.position, moveSpots[nextSpot].position, speed * Time.deltaTime);

		if (Vector2.Distance(transform.position, moveSpots[nextSpot].position) < 0.2f){
			if (waitTime <= 0){
				if (moveForward == true){previousSpot = nextSpot; nextSpot += 1;}
				else if (moveForward == false){previousSpot = nextSpot; nextSpot -= 1;}
					waitTime = startWaitTime;
				} else {
					waitTime -= Time.deltaTime;
				}
		}

		//switch movement direction
		if (nextSpot == 0) {moveForward = true; }
		else if (nextSpot == (moveSpots.Length -1)) {moveForward = false; }

		//turning the NPC
		if (previousSpot < 0){previousSpot = moveSpots.Length -1;}
		else if (previousSpot > moveSpots.Length -1){previousSpot = 0;}

		if ((previousSpot == 0) && (faceRight)){NPCTurn();}
		else if ((previousSpot == (moveSpots.Length -1)) && (!faceRight)) {NPCTurn();}
	  }
	}

	private void NPCTurn(){
		// NOTE: Switch player facing label (avoids constant turning)
		faceRight = !faceRight;

		// NOTE: Multiply player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	} 

	private void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Player") {
			patrolling = false;
			anim.SetBool("Walk", false); 
			gameHandler.ableToShop = true;
		}
	}

	private void OnTriggerExit2D(Collider2D other){
		if (other.gameObject.tag =="Player") {
			StopCoroutine(PatrolAgain());
			StartCoroutine(PatrolAgain());
			gameHandler.ableToShop = false;
		}
	}
	   
	IEnumerator PatrolAgain(){
		yield return new WaitForSeconds(patrolDelay);
		patrolling = true;
		anim.SetBool("Walk", true);
	}
	   
}
