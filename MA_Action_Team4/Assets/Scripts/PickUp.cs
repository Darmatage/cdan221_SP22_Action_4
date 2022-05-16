using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PickUp : MonoBehaviour{

	public GameHandler gameHandler;
	//public playerVFX playerPowerupVFX;
	public bool isHealthPickUp = false;
	public bool isSpeedBoostPickUp = false;

	private AudioSource pickUpSound;
	public AudioSource pickupSFX1;
	public AudioSource pickupSFX2;
	public AudioSource pickupSFX3;


	public int healthBoost = 10;
	public float speedBoost = 2f;
	public float speedTime = 2f;

      void Start(){
            gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
            //playerPowerupVFX = GameObject.FindWithTag("Player").GetComponent<playerVFX>();
			
			//randomize sound for each object
			int PUnum = Random.Range(1,3);
			if (PUnum == 1){pickUpSound = pickupSFX1;}
			else if (PUnum == 2){pickUpSound = pickupSFX2;}
			else if (PUnum == 3){pickUpSound = pickupSFX3;}
      }

      public void OnTriggerEnter2D (Collider2D other){
            if (other.gameObject.tag == "Player"){
                  GetComponent<Collider2D>().enabled = false;
                  //GetComponent<AudioSource>().Play();
                  pickUpSound.Play();
				  StartCoroutine(DestroyThis());

                  if (isHealthPickUp == true) {
                        gameHandler.playerGetHit(healthBoost * -1);
                        //playerPowerupVFX.powerup();
                  }

              //    if (isSpeedBoostPickUp == true) {
                  //      other.gameObject.GetComponent<PlayerMovement>().speedBoost(speedBoost, speedTime);
                        //playerPowerupVFX.powerup();
                  }
            }
          IEnumerator DestroyThis(){
                  yield return new WaitForSeconds(0.3f);
                  Destroy(gameObject);
          }

    }
