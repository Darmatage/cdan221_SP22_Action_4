using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class Furniture : MonoBehaviour {

	//level1 furniture items #1: variables
	public static bool hasDuck = false;
	public static bool hasChair1 = false;
	public static bool hasChair2 = false;




	public GameObject duckOBJ;
	public GameObject chair1OBJ;
	public GameObject chair2OBJ;




	
	void Start(){
	
		//level1 furniture items #2: disable
		duckOBJ.SetActive(false);
		chair1OBJ.SetActive(false);
		chair2OBJ.SetActive(false);
		
		
	}

	void Update (){
		

		//level1 furniture items #3: enable
		if (hasDuck){duckOBJ.SetActive(true);} else {duckOBJ.SetActive(false);}
		if (hasChair1){chair1OBJ.SetActive(true);} else {chair1OBJ.SetActive(false);}
		if (hasChair2){chair2OBJ.SetActive(true);} else {chair2OBJ.SetActive(false);}
		
	

	}

}
