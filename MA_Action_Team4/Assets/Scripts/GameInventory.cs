using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameInventory : MonoBehaviour{

    //5 Inventory Items:
    public GameObject InventoryMenu;
	public GameObject CookMenu;
	private bool InvIsOpen = false;

    public static bool item1bool = false;
    public static bool item2bool = false;
    public static bool item3bool = false;
    public static bool item4bool = false;
    public static bool item5bool = false;
    public static bool item6bool = false;
    public static bool item7bool = false;
    public static bool item8bool = false;
    public static bool item9bool = false;
    public static bool item10bool = false;
    public static bool item11bool = false;

	public static bool cooked1bool = false;
    public static bool cooked2bool = false;
    public static bool cooked3bool = false;
    public static bool cooked4bool = false;
    public static bool cooked5bool = false;
	public static bool cooked6bool = false;

    public GameObject item1image;
    public GameObject item2image;
    public GameObject item3image;
    public GameObject item4image;
    public GameObject item5image;
    public GameObject item6image;
    public GameObject item7image;
    public GameObject item8image;
    public GameObject item9image;
    public GameObject item10image;
    public GameObject item11image;

    public GameObject cooked1image;
    public GameObject cooked2image;
    public GameObject cooked3image;
    public GameObject cooked4image;
    public GameObject cooked5image;
	public GameObject cooked6image; // win condition super slice

    public GameObject item1text;
    public GameObject item2text;
    public GameObject item3text;
    public GameObject item4text;
    public GameObject item5text;
    public GameObject item6text;
    public GameObject item7text;
    public GameObject item8text;
    public GameObject item9text;
    public GameObject item10text;
    public GameObject item11text;

    public GameObject cooked1text;
    public GameObject cooked2text;
    public GameObject cooked3text;
    public GameObject cooked4text;
    public GameObject cooked5text;
	//public GameObject cooked6text; // don't need?

	public static int item1num = 0; //apples
	public static int item2num = 0; //acorn
	public static int item3num = 0; //carrot
	public static int item4num = 0; //mystery meat
	public static int item5num = 0; //daisy
	public static int item6num = 0; //dandy
	public static int item7num = 0; //lemon
	public static int item8num = 0; //mushroom
	public static int item9num = 0; //saltrock
	public static int item10num = 0; //shell
	public static int item11num = 0; //sugar

	public static int cooked1num = 0; //applepie
	public static int cooked2num = 0; //lemonsquare
	public static int cooked3num = 0; //forest feast
	public static int cooked4num = 0; //carrot cake
	public static int cooked5num = 0; //steak dinner
	public static int cooked6num = 0; //SUPER SLICE

	//Cookbook variables:
	public GameObject cookButton1;
    public GameObject cookButton2;
    public GameObject cookButton3;
    public GameObject cookButton4;
    public GameObject cookButton5;
    public GameObject cookButton6;

	public GameObject ingredient1aText;
    public GameObject ingredient1bText;
	public GameObject ingredient2aText;
    public GameObject ingredient2bText;
	public GameObject ingredient3aText;
    public GameObject ingredient3bText;
	public GameObject ingredient4aText;
    public GameObject ingredient4bText;
	public GameObject ingredient5aText;
    public GameObject ingredient5bText;

	public GameObject ingredient6aText;
    public GameObject ingredient6bText;
	public GameObject ingredient6cText;
    public GameObject ingredient6dText;
	public GameObject ingredient6eText;

	private AudioSource eatSound;
	public AudioSource eatSFX1;
	public AudioSource eatSFX2;
	public AudioSource eatSFX3;


    void Start(){
		cooked6image.SetActive(false);
        InventoryMenu.SetActive(false);
		CookMenu.SetActive(false);
        InventoryDisplay();
		
    }

	void Update(){
		
		//cheat code
		if (Input.GetKeyDown("p")){
			InventoryAdd("item1"); InventoryAdd("item1"); InventoryAdd("item1"); InventoryAdd("item1"); InventoryAdd("item1");	
			InventoryAdd("item2"); InventoryAdd("item2"); InventoryAdd("item2"); InventoryAdd("item2"); InventoryAdd("item2"); 
			InventoryAdd("item3"); InventoryAdd("item3"); InventoryAdd("item3"); InventoryAdd("item3"); InventoryAdd("item3"); 
			InventoryAdd("item4"); InventoryAdd("item4"); InventoryAdd("item4"); InventoryAdd("item4"); InventoryAdd("item4"); 
			InventoryAdd("item5"); InventoryAdd("item5"); InventoryAdd("item5"); InventoryAdd("item5"); InventoryAdd("item5");
			InventoryAdd("item6"); InventoryAdd("item6"); InventoryAdd("item6"); InventoryAdd("item6"); InventoryAdd("item6");	
			InventoryAdd("item7"); InventoryAdd("item7"); InventoryAdd("item7"); InventoryAdd("item7"); InventoryAdd("item7"); 
			InventoryAdd("item8"); InventoryAdd("item8"); InventoryAdd("item8"); InventoryAdd("item8"); InventoryAdd("item8"); 
			InventoryAdd("item9"); InventoryAdd("item9"); InventoryAdd("item9"); InventoryAdd("item9"); InventoryAdd("item9"); 
			InventoryAdd("item10"); InventoryAdd("item10"); InventoryAdd("item10"); InventoryAdd("item10"); InventoryAdd("item10"); 
			InventoryAdd("item11"); InventoryAdd("item11"); InventoryAdd("item11"); InventoryAdd("item11"); InventoryAdd("item11");		
		}
	}


    void InventoryDisplay(){
		//Inventory
        if (item1bool == true) { item1image.SetActive(true); } else { item1image.SetActive(false); }
        if (item2bool == true) { item2image.SetActive(true); } else { item2image.SetActive(false); }
        if (item3bool == true) { item3image.SetActive(true); } else { item3image.SetActive(false); }
        if (item4bool == true) { item4image.SetActive(true); } else { item4image.SetActive(false); }
        if (item5bool == true) { item5image.SetActive(true); } else { item5image.SetActive(false); }
        if (item6bool == true) { item6image.SetActive(true); } else { item6image.SetActive(false); }
        if (item7bool == true) { item7image.SetActive(true); } else { item7image.SetActive(false); }
        if (item8bool == true) { item8image.SetActive(true); } else { item8image.SetActive(false); }
        if (item9bool == true) { item9image.SetActive(true); } else { item9image.SetActive(false); }
        if (item10bool == true) { item10image.SetActive(true); } else { item10image.SetActive(false); }
        if (item11bool == true) { item11image.SetActive(true); } else { item11image.SetActive(false); }

		if (cooked1bool == true) { cooked1image.SetActive(true); } else { cooked1image.SetActive(false); }
        if (cooked2bool == true) { cooked2image.SetActive(true); } else { cooked2image.SetActive(false); }
        if (cooked3bool == true) { cooked3image.SetActive(true); } else { cooked3image.SetActive(false); }
        if (cooked4bool == true) { cooked4image.SetActive(true); } else { cooked4image.SetActive(false); }
        if (cooked5bool == true) { cooked5image.SetActive(true); } else { cooked5image.SetActive(false); }
        if (cooked6bool == true) { cooked6image.SetActive(true); } else { cooked6image.SetActive(false); }

        Text itemText1B = item1text.GetComponent<Text>(); itemText1B.text = ("" + item1num);
		Text itemText2B = item2text.GetComponent<Text>(); itemText2B.text = ("" + item2num);
		Text itemText3B = item3text.GetComponent<Text>(); itemText3B.text = ("" + item3num);
		Text itemText4B = item4text.GetComponent<Text>(); itemText4B.text = ("" + item4num);
		Text itemText5B = item5text.GetComponent<Text>(); itemText5B.text = ("" + item5num);
		Text itemText6B = item6text.GetComponent<Text>(); itemText6B.text = ("" + item6num);
		Text itemText7B = item7text.GetComponent<Text>(); itemText7B.text = ("" + item7num);
		Text itemText8B = item8text.GetComponent<Text>(); itemText8B.text = ("" + item8num);
		Text itemText9B = item9text.GetComponent<Text>(); itemText9B.text = ("" + item9num);
		Text itemText10B = item10text.GetComponent<Text>(); itemText10B.text = ("" + item10num);
		Text itemText11B = item11text.GetComponent<Text>(); itemText11B.text = ("" + item11num);

		Text cookedText1B = cooked1text.GetComponent<Text>(); cookedText1B.text = ("" + cooked1num);
		Text cookedText2B = cooked2text.GetComponent<Text>(); cookedText2B.text = ("" + cooked2num);
		Text cookedText3B = cooked3text.GetComponent<Text>(); cookedText3B.text = ("" + cooked3num);
		Text cookedText4B = cooked4text.GetComponent<Text>(); cookedText4B.text = ("" + cooked4num);
		Text cookedText5B = cooked5text.GetComponent<Text>(); cookedText5B.text = ("" + cooked5num);

		//Cookbook:
		if ((item1num >= 2) && (item11num >=1)){cookButton1.SetActive(true);} else {cookButton1.SetActive(false);} // applepie
		if ((item7num >= 2) && (item11num >=1)){cookButton2.SetActive(true);} else {cookButton2.SetActive(false);} //lemonsquare
		if ((item2num >= 5) && (item9num >=1)){cookButton3.SetActive(true);} else {cookButton3.SetActive(false);} //TrailMix
		if ((item8num >= 2) && (item3num >=2)){cookButton4.SetActive(true);} else {cookButton4.SetActive(false);} //MushroomStew
		if ((item4num >= 1) && (item9num >=5)){cookButton5.SetActive(true);} else {cookButton5.SetActive(false);} //SteakDinner
		if ((item4num >= 2) && (item3num >=5) && (item11num >= 5) && (item8num >=5) && (item7num >=3)){
			cookButton6.SetActive(true);} else {cookButton6.SetActive(false);} //supermeal

		//Cookbook Recipes
		Text ingredient1aTextB = ingredient1aText.GetComponent<Text>(); ingredient1aTextB.text = ("" + item1num); //apples
		Text ingredient1bTextB = ingredient1bText.GetComponent<Text>(); ingredient1bTextB.text = ("" + item11num); //sugar
		Text ingredient2aTextB = ingredient2aText.GetComponent<Text>(); ingredient2aTextB.text = ("" + item7num);  //lemon
		Text ingredient2bTextB = ingredient2bText.GetComponent<Text>(); ingredient2bTextB.text = ("" + item11num); //sugar
		Text ingredient3aTextB = ingredient3aText.GetComponent<Text>(); ingredient3aTextB.text = ("" + item2num);  //acorn
		Text ingredient3bTextB = ingredient3bText.GetComponent<Text>(); ingredient3bTextB.text = ("" + item9num); //saltrock
		Text ingredient4aTextB = ingredient4aText.GetComponent<Text>(); ingredient4aTextB.text = ("" + item8num);  //mushroom
		Text ingredient4bTextB = ingredient4bText.GetComponent<Text>(); ingredient4bTextB.text = ("" + item3num); //carrot
		Text ingredient5aTextB = ingredient5aText.GetComponent<Text>(); ingredient5aTextB.text = ("" + item4num);  //meat
		Text ingredient5bTextB = ingredient5bText.GetComponent<Text>(); ingredient5bTextB.text = ("" + item9num);  //salt
		
		Text ingredient6aTextB = ingredient6aText.GetComponent<Text>(); ingredient6aTextB.text = ("" + item4num); //meat
		Text ingredient6bTextB = ingredient6bText.GetComponent<Text>(); ingredient6bTextB.text = ("" + item3num); //carrot
		Text ingredient6cTextB = ingredient6cText.GetComponent<Text>(); ingredient6cTextB.text = ("" + item11num); //sugar
		Text ingredient6dTextB = ingredient6dText.GetComponent<Text>(); ingredient6dTextB.text = ("" + item8num); //mushroom
		Text ingredient6eTextB = ingredient6eText.GetComponent<Text>(); ingredient6eTextB.text = ("" + item7num); //lemon

	}

    public void InventoryAdd(string item){
        string foundItemName = item;
        if (foundItemName == "item1") { item1bool = true; item1num++;}
        else if (foundItemName == "item2") { item2bool = true; item2num++; }
        else if (foundItemName == "item3") { item3bool = true; item3num++; }
        else if (foundItemName == "item4") { item4bool = true; item4num++; }
        else if (foundItemName == "item5") { item5bool = true; item5num++; }
	    else if (foundItemName == "item6") { item6bool = true; item6num++; }
        else if (foundItemName == "item7") { item7bool = true; item7num++; }
        else if (foundItemName == "item8") { item8bool = true; item8num++; }
        else if (foundItemName == "item9") { item9bool = true; item9num++; }
	    else if (foundItemName == "item10") { item10bool = true; item10num++; }
	    else if (foundItemName == "item11") { item11bool = true; item11num++; }

	    else if (foundItemName == "cooked1") { cooked1bool = true; cooked1num++; }
		else if (foundItemName == "cooked2") { cooked2bool = true; cooked2num++; }
        else if (foundItemName == "cooked3") { cooked3bool = true; cooked3num++; }
        else if (foundItemName == "cooked4") { cooked4bool = true; cooked4num++; }
        else if (foundItemName == "cooked5") { cooked5bool = true; cooked5num++; }
		else if (foundItemName == "cooked6") { cooked6bool = true; cooked6num++; }

        InventoryDisplay();

		if (!InvIsOpen){
			OpenCloseInventory();
		}
    }

    public void InventoryRemove(string item, int num){
        string itemRemove = item;
        if (itemRemove == "item1") { item1num -= num; if (item1num<=0){item1bool = false;} }
        else if (itemRemove == "item2") { item2num -= num;if (item2num<=0){item2bool = false;} }
        else if (itemRemove == "item3") { item3num -= num;if (item3num<=0){item3bool = false;} }
        else if (itemRemove == "item4") { item4num -= num;if (item4num<=0){item4bool = false;} }
        else if (itemRemove == "item5") { item5num -= num;if (item5num<=0){item5bool = false;} }
        else if (itemRemove == "item6") { item6num -= num;if (item6num<=0){item6bool = false;} }
        else if (itemRemove == "item7") { item7num -= num;if (item7num<=0){item7bool = false;} }
        else if (itemRemove == "item8") { item8num -= num;if (item8num<=0){item8bool = false;} }
        else if (itemRemove == "item9") { item9num -= num;if (item9num<=0){item9bool = false;} }
        else if (itemRemove == "item10") { item10num -= num;if (item10num<=0){item10bool = false;} }
        else if (itemRemove == "item11") { item11num -= num;if (item11num<=0){item11bool = false;} }

        else if (itemRemove == "cooked1") { cooked1num -= num;if (cooked1num<=0){cooked1bool = false;} }
		else if (itemRemove == "cooked2") { cooked2num -= num;if (cooked2num<=0){cooked2bool = false;} }
        else if (itemRemove == "cooked3") { cooked3num -= num;if (cooked3num<=0){cooked3bool = false;} }
        else if (itemRemove == "cooked4") { cooked4num -= num;if (cooked4num<=0){cooked4bool = false;} }
        else if (itemRemove == "cooked5") { cooked5num -= num;if (cooked5num<=0){cooked5bool = false;} }

		InventoryDisplay();
    }


	//Open and Close the Inventory
	public void OpenCloseInventory(){
		if (InvIsOpen){InventoryMenu.SetActive(false);}
		else {InventoryMenu.SetActive(true);}
		InvIsOpen = !InvIsOpen;
	}

	//Open and Close the Cookbook
	public void OpenCookBook(){CookMenu.SetActive(true);}
	public void CloseCookBook(){CookMenu.SetActive(false);}


	//Cooked food add button functions
	public void AddCooked1(){
		InventoryAdd("cooked1");
		InventoryRemove("item1", 2); InventoryRemove("item11", 1);
		}
	public void AddCooked2(){
		InventoryAdd("cooked2");
		InventoryRemove("item7", 2); InventoryRemove("item11", 1);
		}
	public void AddCooked3(){
		InventoryAdd("cooked3");
		InventoryRemove("item2", 5); InventoryRemove("item9", 1);
		}
	public void AddCooked4(){
		InventoryAdd("cooked4");
		InventoryRemove("item8", 2); InventoryRemove("item3", 2); 
	}
	public void AddCooked5(){
		InventoryAdd("cooked5");
		InventoryRemove("item4", 1); InventoryRemove("item9", 5);
	}
	public void AddCooked6(){
		InventoryAdd("cooked6");
		InventoryRemove("item4", 2); 
		InventoryRemove("item3", 5);
		InventoryRemove("item11", 5); 
		InventoryRemove("item8", 5);
		InventoryRemove("item7", 3);
		CookMenu.SetActive(false);
	}


	//Cooked food eating button functions
	public void EatCooked1(){
		InventoryRemove("cooked1", 1);
		GetComponent<GameHandler>().eatFood(20);
		
		//randomize sound for each object
			int PUnum = Random.Range(1,3);
			if (PUnum == 1){eatSound = eatSFX1;}
			else if (PUnum == 2){eatSound = eatSFX2;}
			else if (PUnum == 3){eatSound = eatSFX3;}
			
			eatSound.Play();
	}

	public void EatCooked2(){
		InventoryRemove("cooked2", 1);
		GetComponent<GameHandler>().eatFood(20);
		
		//randomize sound for each object
			int PUnum = Random.Range(1,3);
			if (PUnum == 1){eatSound = eatSFX1;}
			else if (PUnum == 2){eatSound = eatSFX2;}
			else if (PUnum == 3){eatSound = eatSFX3;}
			
			eatSound.Play();
	}

	public void EatCooked3(){
		InventoryRemove("cooked3", 1);
		GetComponent<GameHandler>().eatFood(35);
		
		//randomize sound for each object
			int PUnum = Random.Range(1,3);
			if (PUnum == 1){eatSound = eatSFX1;}
			else if (PUnum == 2){eatSound = eatSFX2;}
			else if (PUnum == 3){eatSound = eatSFX3;}
			
			eatSound.Play();
	}


	public void EatCooked4(){
		InventoryRemove("cooked4", 1);
		GetComponent<GameHandler>().eatFood(45);
		
		//randomize sound for each object
			int PUnum = Random.Range(1,3);
			if (PUnum == 1){eatSound = eatSFX1;}
			else if (PUnum == 2){eatSound = eatSFX2;}
			else if (PUnum == 3){eatSound = eatSFX3;}
			
			eatSound.Play();
	}


	public void EatCooked5(){
		InventoryRemove("cooked5", 1);
		GetComponent<GameHandler>().eatFood(55);
		
		//randomize sound for each object
			int PUnum = Random.Range(1,3);
			if (PUnum == 1){eatSound = eatSFX1;}
			else if (PUnum == 2){eatSound = eatSFX2;}
			else if (PUnum == 3){eatSound = eatSFX3;}
			
			eatSound.Play();
	}

	public void EatCooked6(){
		InventoryRemove("cooked5", 1);
		GetComponent<GameHandler>().eatFood(100);
		
		//randomize sound for each object
			int PUnum = Random.Range(1,3);
			if (PUnum == 1){eatSound = eatSFX1;}
			else if (PUnum == 2){eatSound = eatSFX2;}
			else if (PUnum == 3){eatSound = eatSFX3;}
		
		eatSound.Play();
		
		cooked6image.SetActive(false);
		ResetAllInventory();
		SceneManager.LoadScene("Win");
	}


	public void ResetAllInventory(){
		
		item1bool = false;
		item2bool = false;
		item3bool = false;
		item4bool = false;
		item5bool = false;
		item6bool = false;
		item7bool = false;
		item8bool = false;
		item9bool = false;
		item10bool = false;
		item11bool = false;

		cooked1bool = false;
		cooked2bool = false;
		cooked3bool = false;
		cooked4bool = false;
		cooked5bool = false;
		cooked6bool = false;
		
	
		item1num = 0; //apples
		item2num = 0; //acorn
		item3num = 0; //carrot
		item4num = 0; //mystery meat
		item5num = 0; //daisy
		item6num = 0; //dandy
		item7num = 0; //lemon
		item8num = 0; //mushroom
		item9num = 0; //saltrock
		item10num = 0; //shell
		item11num = 0; //sugar

		cooked1num = 0; //applepie
		cooked2num = 0; //lemonsquare
		cooked3num = 0; //forest feast
		cooked4num = 0; //carrot cake
		cooked5num = 0; //steak dinner
		cooked6num = 0; //SUPER SLICE
		
		Furniture.hasBed = false;
		Furniture.hasTable = false;
		Furniture.hasChair1 = false;
		Furniture.hasChair2 = false;
		Furniture.hasSink = false;
		Furniture.hasCouch = false;
		Furniture.hasRug = false;
		Furniture.hasDuck = false;

	}

}
