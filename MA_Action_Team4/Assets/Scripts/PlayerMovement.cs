using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour{

	public float moveSpeed = 2f;
	public static float moveSpeedCurrent;

	public Rigidbody2D rb;
	public Animator animator;
	public GameHandler gameHandler;
	public bool losingStamina = false;
	public bool dashing = false;
	public int damage = 1;
	public float damageTime = 1f;
	public float timer = 0;

	Vector2 movement;

	public AudioSource step1;
	public AudioSource step2;
	public AudioSource step3;
	public AudioSource step4;
	public AudioSource step5;
	public AudioSource step6;
	private AudioSource StepToPlay;

	void Start(){
		gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
		moveSpeedCurrent = moveSpeed;

	}

    void Update(){
	//input
		movement.x = Input.GetAxisRaw("Horizontal");
		movement.y = Input.GetAxisRaw("Vertical");

		animator.SetFloat("Horizontal", movement.x);
		animator.SetFloat("Vertical", movement.y);
		animator.SetFloat("Speed", movement.sqrMagnitude);

		if (Input.GetKey("left shift")){
			dashing = true;
			moveSpeedCurrent = moveSpeed *2; //speed up when dashing
		}
		
		if (Input.GetKeyUp("left shift")){
			dashing = false;
			moveSpeedCurrent = moveSpeed;
		}

		if((Input.GetAxisRaw("Horizontal")!= 0)||(Input.GetAxisRaw("Vertical")!= 0)){
			losingStamina = true;
			PlaySteps();
		}else{
			losingStamina= false;
			StopSteps();
		}
	}

	void FixedUpdate(){
		rb.MovePosition(rb.position + movement * moveSpeedCurrent * Time.fixedDeltaTime);

		if(losingStamina == true){
			if (!dashing){ 
				timer += 0.01f; 
			} else { 
				timer += 0.04f; //speed up stamina loss when dashing
			}
			
			if(timer >= damageTime){
				timer = 0;
				gameHandler.playerGetHit(damage);
				Debug.Log("player lost stamina");
			}
		}
    }
	
	public void PlaySteps(){
		if ((StepToPlay !=null)&&(StepToPlay.isPlaying)){
			return;
		}
		else {
			int StepNum = Random.Range(1, 6);
		
			if (StepNum == 1){ StepToPlay = step1;}
			else if (StepNum == 2){ StepToPlay = step2;}
			else if (StepNum == 3){ StepToPlay = step3;}
			else if (StepNum == 4){ StepToPlay = step4;}
			else if (StepNum == 5){ StepToPlay = step5;}
			else if (StepNum == 6){ StepToPlay = step6;}
		
			StepToPlay.Play();
			Debug.Log("I am playing " + StepToPlay);
		}
	}
	
	public void StopSteps(){
		if ((StepToPlay !=null)&&(StepToPlay.isPlaying)){
			StepToPlay.Stop();
		}
	}
	
}
