using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameHandler_PlayerReturn : MonoBehaviour {

	public static string lastMap = "";
	public static Vector2 lastDoorPosition;        // where the Player entered a door
	private string thisLevel;
	private Transform player;
	private Transform mainCamera;

	//these variables are just to manage the door between levels 2 and 3:
	public static bool leftLevel2 = false;
	public static bool leftLevel3 = false;


	void Start() {
		thisLevel = SceneManager.GetActiveScene().name;
		player = GameObject.FindWithTag("Player").GetComponent<Transform>();
		mainCamera = GameObject.FindWithTag("MainCamera").GetComponent<Transform>();
		
		//level 1 doors
		if ((leftLevel3 == true)&&(thisLevel == "Level1")){
			if (GameObject.FindWithTag("StartHere")!= null){
					Vector3 startPos = GameObject.FindWithTag("StartHere").transform.position;
					player.position = startPos;
					mainCamera.position = new Vector3(startPos.x, startPos.y, -10);
				}
			leftLevel3=false;
			
		}
		
		else if (thisLevel == lastMap){
			player.position = lastDoorPosition;
			mainCamera.position = new Vector3(lastDoorPosition.x, lastDoorPosition.y, -10);
		}
		
		
		//these 3 functions are just to manage the door between levels 2 and 3:
		if ((thisLevel != "Level2")&&(thisLevel != "Level3")){
			leftLevel2 = false;
			leftLevel3 = false;
		}
		
		else if (thisLevel == "Level3"){
			leftLevel3 = true;
			Debug.Log("I am in Level3.  Was I just in Level2?: " + leftLevel2);
			
			if (leftLevel2 == true){
			//position player at level3 door from level2 
			if (GameObject.FindWithTag("StartHere")!= null){
				Vector3 startPos = GameObject.FindWithTag("StartHere").transform.position;
				player.position = startPos;
				mainCamera.position = new Vector3(startPos.x, startPos.y, -10);
				
				Debug.Log("I am moving to StartHere in Level3");
			}
			leftLevel2=false;
			}
		}		

		else if (thisLevel == "Level2"){
			leftLevel2 = true;
			Debug.Log("I am in Level2. Was I just in Level3?: " + leftLevel3);
			//Debug.Log("I am in this Level: " + SceneManager.GetActiveScene().name);
		
			if(leftLevel3 == true){
			//position player at level3 door from level2
				if (GameObject.FindWithTag("StartHere")!= null){
					Vector3 startPos = GameObject.FindWithTag("StartHere").transform.position;
					player.position = startPos;
					mainCamera.position = new Vector3(startPos.x, startPos.y, -10);
				}
				leftLevel3=false;
			}
		}
	}
	
}
