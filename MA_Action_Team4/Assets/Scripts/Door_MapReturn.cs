using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door_MapReturn : MonoBehaviour {

	public string NextLevel = "MainMenu";
	public GameObject msgPressE;
	public bool canPressE = false;
	   
	private string thisLevel;
	private Vector2 doorReturnPos;   // load with location for player when they return
	public float offsetX = 0f;       // distance to left or right of the door for player to spawn
	public float offsetY = -2f;      // distance above or below the door for player to spawn
      
	public bool isLevel1Furniture = false;
	 

	void Start() {
		thisLevel = SceneManager.GetActiveScene().name;
		doorReturnPos = new Vector2((transform.position.x + offsetX), (transform.position.y + offsetY));
		msgPressE.SetActive(false);
	}

	void Update(){
		if ((canPressE == true) && (Input.GetKeyDown(KeyCode.E))){
			EnterDoor();
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Player"){ ;
			msgPressE.SetActive(true);
			canPressE = true;
		}
	}

	void OnTriggerExit2D(Collider2D other){
		if (other.gameObject.tag == "Player"){
			msgPressE.SetActive(false);
			canPressE = false;
		}
	}

	public void EnterDoor(){
		if (isLevel1Furniture){
			GameObject.FindWithTag("GameHandler").GetComponent<Furniture>().SaveFurniturePositions();
		}
		GameHandler_PlayerReturn.lastDoorPosition = doorReturnPos;
		GameHandler_PlayerReturn.lastMap = thisLevel;
		SceneManager.LoadScene (NextLevel);
		Debug.Log("Leaving " + thisLevel + ". Door Rerturn Poisiton = " + doorReturnPos);
		
		
	}
	
	// public void OnTriggerEnter2D(Collider2D other) {
		// if (other.gameObject.tag == "Player"){
			// GameHandler_PlayerReturn.lastDoorPosition = doorReturnPos;
			// GameHandler_PlayerReturn.lastMap = thisLevel;
			// SceneManager.LoadScene (NextLevel);
		// }
	// }
	
} 