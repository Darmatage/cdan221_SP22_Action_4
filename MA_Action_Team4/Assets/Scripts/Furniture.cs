using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Furniture : MonoBehaviour {

	//level1 furniture items #1: variables
	public static bool hasBed = false;
	public static bool hasTable = false;
	public static bool hasChair1 = false;
	public static bool hasChair2 = false;
	public static bool hasSink = false;
	public static bool hasCouch = false;
	public static bool hasRug = false;
	public static bool hasDuck = false;

	public GameObject bedOBJ;
	public GameObject tableOBJ;
	public GameObject chair1OBJ;
	public GameObject chair2OBJ;
	public GameObject sinkOBJ;
	public GameObject couchOBJ;
	public GameObject rugOBJ;
	public GameObject duckOBJ;
	
	public static Vector3 posBed;
	public static Vector3 posTable;
	public static Vector3 posChair1;
	public static Vector3 posChair2;
	public static Vector3 posSink;
	public static Vector3 posCouch;
	public static Vector3 posRug;
	public static Vector3 posDuck;
	
	
	void Start(){
		//if furniture is visible, position based on Vector3, for movement
		//otherwise, set default position
		if (SceneManager.GetActiveScene().name == "Level1"){
			if (hasBed){bedOBJ.transform.position = posBed;}
			else {posBed = bedOBJ.transform.position;}
			if (hasTable){tableOBJ.transform.position = posTable;}
			else {posTable = tableOBJ.transform.position;}
			if (hasChair1){chair1OBJ.transform.position = posChair1;}
			else {posChair1 = chair1OBJ.transform.position;}
			if (hasChair2){chair2OBJ.transform.position = posChair2;}
			else {posChair2 = chair2OBJ.transform.position;}
			if (hasSink){sinkOBJ.transform.position = posSink;}
			else {posSink = sinkOBJ.transform.position;}
			if (hasCouch){couchOBJ.transform.position = posCouch;}	
			else {posCouch = couchOBJ.transform.position;}
			if (hasRug){rugOBJ.transform.position = posRug;}	
			else {posRug = rugOBJ.transform.position;}
			if (hasDuck){duckOBJ.transform.position = posDuck;}
			else {posDuck = duckOBJ.transform.position;}
		}
	}
	
	void Update (){
		//level1 furniture items #2: enable / disable
		//if (SceneManager.GetActiveScene().name == "Level1"){
			if (hasBed){bedOBJ.SetActive(true);} else {bedOBJ.SetActive(false);}
			if (hasTable){tableOBJ.SetActive(true);} else {tableOBJ.SetActive(false);}
			if (hasChair1){chair1OBJ.SetActive(true);} else {chair1OBJ.SetActive(false);}
			if (hasChair2){chair2OBJ.SetActive(true);} else {chair2OBJ.SetActive(false);}
			if (hasSink){sinkOBJ.SetActive(true);} else {sinkOBJ.SetActive(false);}
			if (hasCouch){couchOBJ.SetActive(true);} else {couchOBJ.SetActive(false);}
			if (hasRug){rugOBJ.SetActive(true);} else {rugOBJ.SetActive(false);}
			if (hasDuck){duckOBJ.SetActive(true);} else {duckOBJ.SetActive(false);}
		//}
	}

	public void SaveFurniturePositions(){
		//update visible furniture position variable for next time we are in this scene 
		if (SceneManager.GetActiveScene().name == "Level1"){
			if (hasBed){posBed = bedOBJ.transform.position;}
			if (hasTable){posTable = tableOBJ.transform.position;}
			if (hasChair1){posChair1 = chair1OBJ.transform.position;}
			if (hasChair2){posChair2 = chair2OBJ.transform.position;}
			if (hasSink){posSink = sinkOBJ.transform.position;}
			if (hasCouch){posCouch = couchOBJ.transform.position;}
			if (hasRug){posRug = rugOBJ.transform.position;}
			if (hasDuck){posDuck = duckOBJ.transform.position;}	
		}		
	}

}
