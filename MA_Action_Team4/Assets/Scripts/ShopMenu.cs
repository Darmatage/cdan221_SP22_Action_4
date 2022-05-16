using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.Audio;

public class ShopMenu : MonoBehaviour{

	public Furniture furnitureControl;
	public GameInventory gameInventory;
	public static bool ShopisOpen = false;
	public GameObject shopMenuUI;
	public GameObject buttonOpenShop;
	
	private GameHandler gameHandler;

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

	  
	public AudioSource KaChingSFX;

	void Start (){
		shopMenuUI.SetActive(false);
		//buttonOpenShop.SetActive(false);
		gameInventory = GetComponent<GameInventory>();
		furnitureControl = GetComponent<Furniture>();
		gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
		gameHandler.ableToShop = false;
	}

	void Update (){
		if ((GameInventory.item1num >= furniture1Cost) && (Furniture.hasBed == false)) {
			item1BuyButton.SetActive(true);}
		else { item1BuyButton.SetActive(false);}

		if ((GameInventory.item2num >= furniture2Cost) && (Furniture.hasTable == false)) {
			item2BuyButton.SetActive(true);}
		else { item2BuyButton.SetActive(false);}

		if ((GameInventory.item3num >= furniture3Cost) && (Furniture.hasChair1 == false)) {
			item3BuyButton.SetActive(true);}
		else { item3BuyButton.SetActive(false);}
		
		if ((GameInventory.item3num >= furniture4Cost) && (Furniture.hasChair2 == false)) {
			item4BuyButton.SetActive(true);}
		else { item4BuyButton.SetActive(false);}

		if ((GameInventory.item8num >= furniture5Cost) && (Furniture.hasSink == false)) {
			item5BuyButton.SetActive(true);}
		else { item5BuyButton.SetActive(false);}

		if ((GameInventory.item5num >= furniture6Cost) && (Furniture.hasCouch == false)) {
			item6BuyButton.SetActive(true);}
		else { item6BuyButton.SetActive(false);}

		if ((GameInventory.item6num >= furniture7Cost) && (Furniture.hasRug == false)) {
			item7BuyButton.SetActive(true);}
		else { item7BuyButton.SetActive(false);}

		if ((GameInventory.item11num >= furniture8Cost) && (Furniture.hasDuck == false)) {
			item8BuyButton.SetActive(true);}
		else { item8BuyButton.SetActive(false);}

      }

      //Shop Button Functions:
      public void Button_OpenShop(){
           shopMenuUI.SetActive(true);
           gameHandler.ableToShop = true;
           ShopisOpen = true;
           Time.timeScale = 0f;
      }

      public void Button_CloseShop() {
           shopMenuUI.SetActive(false);
           gameHandler.ableToShop = true;
           ShopisOpen = false;
           Time.timeScale = 1f;
      }

	//shop button visibility triggered by shopkeeper
	// public void ShowShopButton(){
		// buttonOpenShop.SetActive(true);
	// }
	
	// public void HideShopButton(){
		// buttonOpenShop.SetActive(false);
	// }


	//trade button functions
	
	//get bed for apples
	public void Button_BuyFurniture1(){
		gameInventory.InventoryRemove("item1", furniture1Cost);
		Furniture.hasBed = true;
		KaChingSFX.Play();
	}

	//get table for acorns
	public void Button_BuyFurniture2(){
		gameInventory.InventoryRemove("item2", furniture2Cost);
		Furniture.hasTable = true;
		KaChingSFX.Play();
	}

	//get chair1 for carrot
	public void Button_BuyFurniture3(){
		gameInventory.InventoryRemove("item3", furniture3Cost);
		Furniture.hasChair1 = true;
		KaChingSFX.Play();
	}

	//get chair2 for carrot	
	public void Button_BuyFurniture4(){
		gameInventory.InventoryRemove("item3", furniture4Cost);
		Furniture.hasChair2 = true;
		KaChingSFX.Play();
	}

	//get sink for mushrooms
	public void Button_BuyFurniture5(){
		gameInventory.InventoryRemove("item8", furniture5Cost);
		Furniture.hasSink = true;
		KaChingSFX.Play();
	}

	//get couch for daisy
	public void Button_BuyFurniture6(){
		gameInventory.InventoryRemove("item5", furniture6Cost);
		Furniture.hasCouch = true;
		KaChingSFX.Play();
	}

	//get rug for dandy
	public void Button_BuyFurniture7(){
		gameInventory.InventoryRemove("item6", furniture7Cost);
		Furniture.hasRug = true;
		KaChingSFX.Play();
	}

	//get duck for sugar
	public void Button_BuyFurniture8(){
		gameInventory.InventoryRemove("item11", furniture8Cost);
		Furniture.hasDuck = true;
		KaChingSFX.Play();
	}

}
