using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.Audio;

public class ShopMenu : MonoBehaviour{

	public Furniture furnitureControl;
	public GameHandler gameHandler;
	public static bool ShopisOpen = false;
	public GameObject shopMenuUI;
	public GameObject buttonOpenShop;

	public GameObject item1BuyButton;
	public GameObject item2BuyButton;
	public GameObject item3BuyButton;
	public GameObject item4BuyButton;
	public GameObject item5BuyButton;
	public GameObject item6BuyButton;
	public GameObject item7BuyButton;
	public GameObject item8BuyButton;	
	  
	public int furniture1Cost = 2; //bed = 2 apples
	public int furniture2Cost = 2; //table = 2 acorns
	public int furniture3Cost = 1; //chair1 = 1 carrot
	public int furniture4Cost = 1; //chair2 = 1 carrot
	public int furniture5Cost = 3; //sink = 3 mushroom
	public int furniture6Cost = 1; //couch = 1 daisy
	public int furniture7Cost = 1; //rug = 1 dandy
	public int furniture8Cost = 5; //duck = 5 sugar

	  
	//public AudioSource KaChingSFX;

	void Start (){
		shopMenuUI.SetActive(false);
		//buttonOpenShop.SetActive(false);
		gameHandler = GetComponent<GameHandler>();
		furnitureControl = GetComponent<Furniture>();
	}

	void Update (){
		if ((GameInventory.item1num >= item1Cost) && (Furniture.hasBed == false)) {
			item1BuyButton.SetActive(true);}
		else { item1BuyButton.SetActive(false);}

		if ((GameInventory.item1num >= item2Cost) && (Furniture.hasTable == false)) {
			item2BuyButton.SetActive(true);}
		else { item2BuyButton.SetActive(false);}

		if ((GameInventory.item1num >= item3Cost) && (Furniture.hasChair1 == false)) {
			item3BuyButton.SetActive(true);}
		else { item3BuyButton.SetActive(false);}
		
		if ((GameInventory.item1num >= item4Cost) && (Furniture.hasChair2 == false)) {
			item4BuyButton.SetActive(true);}
		else { item4BuyButton.SetActive(false);}

		if ((GameInventory.item1num >= item5Cost) && (Furniture.hasSink == false)) {
			item5BuyButton.SetActive(true);}
		else { item5BuyButton.SetActive(false);}

		if ((GameInventory.item1num >= item6Cost) && (Furniture.hasCouch == false)) {
			item6BuyButton.SetActive(true);}
		else { item6BuyButton.SetActive(false);}

		if ((GameInventory.item1num >= item7Cost) && (Furniture.hasRug == false)) {
			item7BuyButton.SetActive(true);}
		else { item7BuyButton.SetActive(false);}

		if ((GameInventory.item11num >= item8Cost) && (Furniture.hasDuck == false)) {
			item8BuyButton.SetActive(true);}
		else { item8BuyButton.SetActive(false);}

      }

      //Button Functions:
      public void Button_OpenShop(){
           shopMenuUI.SetActive(true);
           buttonOpenShop.SetActive(false);
           ShopisOpen = true;
           Time.timeScale = 0f;
      }

      public void Button_CloseShop() {
           shopMenuUI.SetActive(false);
           buttonOpenShop.SetActive(true);
           ShopisOpen = false;
           Time.timeScale = 1f;
      }

	//triggered by shopkeeper
	public void ShowShopButton(){
		buttonOpenShop.SetActive(true);
	}
	
	public void HideShopButton(){
		buttonOpenShop.SetActive(false);
	}


	//trade variables
	
	//get bed for apples
	public void Button_BuyFurniture1(){
		GameInventory.InventoryRemove(item1num, furniture1Cost);
		Furniture.hasBed = true;
		//KaChingSFX.Play();
	}

	//get table for acorns
	public void Button_BuyFurniture2(){
		GameInventory.InventoryRemove(item2num, furniture2Cost);
		Furniture.hasTable = true;
		//KaChingSFX.Play();
	}

	public void Button_BuyFurniture3(){
		GameInventory.InventoryRemove(item1num, furniture3Cost);
		Furniture.hasChair1 = true;
		//KaChingSFX.Play();
	}
	
	public void Button_BuyFurniture4(){
		GameInventory.InventoryRemove(item1num, furniture4Cost);
		Furniture.hasChair2 = true;
		//KaChingSFX.Play();
	}

	public void Button_BuyFurniture5(){
		GameInventory.InventoryRemove(item1num, furniture5Cost);
		Furniture.hasSink = true;
		//KaChingSFX.Play();
	}

	public void Button_BuyFurniture6(){
		GameInventory.InventoryRemove(item1num, furniture6Cost);
		Furniture.hasCouch = true;
		//KaChingSFX.Play();
	}

	public void Button_BuyFurniture7(){
		GameInventory.InventoryRemove(item1num, furniture7Cost);
		Furniture.hasRug = true;
		//KaChingSFX.Play();
	}

	public void Button_BuyFurniture8(){
		GameInventory.InventoryRemove(item11num, furniture8Cost);
		Furniture.hasDuck = true;
		//KaChingSFX.Play();
	}

}
