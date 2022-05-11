using System.Collections.Generic;
using System.Collections;
using UnityEngine;

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
	
	void Update (){
		
		//level1 furniture items #2: enable / disable
		if (hasBed){bedOBJ.SetActive(true);} else {bedOBJ.SetActive(false);}
		if (hasTable){tableOBJ.SetActive(true);} else {tableOBJ.SetActive(false);}
		if (hasChair1){chair1OBJ.SetActive(true);} else {chair1OBJ.SetActive(false);}
		if (hasChair2){chair2OBJ.SetActive(true);} else {chair2OBJ.SetActive(false);}
		if (hasSink){sinkOBJ.SetActive(true);} else {sinkOBJ.SetActive(false);}
		if (hasCouch){couchOBJ.SetActive(true);} else {couchOBJ.SetActive(false);}
		if (hasRug){rugOBJ.SetActive(true);} else {rugOBJ.SetActive(false);}
		if (hasDuck){duckOBJ.SetActive(true);} else {duckOBJ.SetActive(false);}

	}

}
