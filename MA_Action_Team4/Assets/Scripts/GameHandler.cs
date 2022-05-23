using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class GameHandler : MonoBehaviour {

	//pause menu variables
	public static bool GameisPaused = false;
	public GameObject pauseMenuUI;
	public AudioMixer mixer;
	public static float volumeLevel = 1.0f;
	private Slider sliderVolumeCtrl;

	public GameObject ButtonOpenShop;
	public bool ableToShop = false;

	private GameObject player;
	public static int playerStamina = 100;
	public int StartPlayerStamina = 100;
	public GameObject staminaText;

	public static int gotTokens = 0;
	public GameObject tokensText;

	public bool isDefending = false;

	public static bool stairCaseUnlocked = false;
	//this is a flag check. Add to other scripts: GameHandler.stairCaseUnlocked = true;

	public static bool gotitem1 = false;
	public static bool gotitem2 = false;
	public static bool gotitem3 = false;

	private string sceneName;
	
	
	void Awake (){
		SetLevel (volumeLevel);
		GameObject sliderTemp = GameObject.FindWithTag("PauseMenuSlider");
		if (sliderTemp != null){
			sliderVolumeCtrl = sliderTemp.GetComponent<Slider>();
			sliderVolumeCtrl.value = volumeLevel;
		}
	}

	void Start(){
		pauseMenuUI.SetActive(false);
		GameisPaused = false;
		player = GameObject.FindWithTag("Player");
		sceneName = SceneManager.GetActiveScene().name;

		if (sceneName=="MainMenu"){ //uncomment these two lines when the MainMenu exists
			playerStamina = StartPlayerStamina;
		}
		updateStatsDisplay();
		ButtonOpenShop.SetActive(false);
		
		
	}

	void Update (){
		if (Input.GetKeyDown(KeyCode.Escape)){
			if (GameisPaused){
				Resume();
			}
			else{
				Pause();
			}
		}

		if(ableToShop == true){
			ButtonOpenShop.SetActive(true);
		}
		else{
			ButtonOpenShop.SetActive(false);
		}

	}

	void Pause(){
		pauseMenuUI.SetActive(true);
		Time.timeScale = 0f;
		GameisPaused = true;
	}

	public void Resume(){
		pauseMenuUI.SetActive(false);
		Time.timeScale = 1f;
		GameisPaused = false;
	}

	public void SetLevel (float sliderValue){
		mixer.SetFloat("MusicVolume", Mathf.Log10 (sliderValue) * 20);
		volumeLevel = sliderValue;
	}

	public void playerGetTokens(int newTokens){
		gotTokens += newTokens;
		updateStatsDisplay();
	}

	public void playerGetHit(int damage){
		if (isDefending == false){
			playerStamina -= damage;
			if (playerStamina >=0){
				updateStatsDisplay();
			}
		//	player.GetComponent<PlayerHurt>().playerHit();
		}

		if (playerStamina >= StartPlayerStamina){
			playerStamina = StartPlayerStamina;
		}

		if (playerStamina <= 0){
			playerStamina = 0;
			playerDies();
		}
	}

	public void eatFood(int calories){
		playerStamina += calories;
		if (playerStamina >= StartPlayerStamina){
                  playerStamina = StartPlayerStamina;
        }
		updateStatsDisplay();
		//make a cool effect to show improvement!
	}


	public void updateStatsDisplay(){
		Text staminaTextTemp = staminaText.GetComponent<Text>();
		staminaTextTemp.text = "HUNGER: " + playerStamina;

		Text tokensTextTemp = tokensText.GetComponent<Text>();
		tokensTextTemp.text = "WATER: " + gotTokens;
	}

	public void playerDies(){
		//      player.GetComponent<PlayerHurt>().playerDead();
		StartCoroutine(DeathPause());
	}

	IEnumerator DeathPause(){
        //    player.GetComponent<PlayerMove>().isAlive = false;
        //    player.GetComponent<PlayerJump>().isAlive = false;
		yield return new WaitForSeconds(1.0f);
		SceneManager.LoadScene("Lose");
	}

	public void StartGame() {
		SceneManager.LoadScene("Level1");
		ResetAllInventoryFurniture();
	}

	public void RestartGame() {
		Time.timeScale = 1f;
		SceneManager.LoadScene("MainMenu");
		playerStamina = StartPlayerStamina;
		ResetAllInventoryFurniture();	
	}

	public void QuitGame() {
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		#else
		Application.Quit();
		#endif
	}

	public void Credits() {
		SceneManager.LoadScene("Credits");
	}
	  
	public void ResetAllInventoryFurniture(){
		
		//reset starting position in level1
		GameHandler_PlayerReturn.lastMap = "";
		
		//reset all inventory
		GameInventory.item1bool = false;
		GameInventory.item2bool = false;
		GameInventory.item3bool = false;
		GameInventory.item4bool = false;
		GameInventory.item5bool = false;
		GameInventory.item6bool = false;
		GameInventory.item7bool = false;
		GameInventory.item8bool = false;
		GameInventory.item9bool = false;
		GameInventory.item10bool = false;
		GameInventory.item11bool = false;

		GameInventory.cooked1bool = false;
		GameInventory.cooked2bool = false;
		GameInventory.cooked3bool = false;
		GameInventory.cooked4bool = false;
		GameInventory.cooked5bool = false;
		GameInventory.cooked6bool = false;
		
	
		GameInventory.item1num = 0; //apples
		GameInventory.item2num = 0; //acorn
		GameInventory.item3num = 0; //carrot
		GameInventory.item4num = 0; //mystery meat
		GameInventory.item5num = 0; //daisy
		GameInventory.item6num = 0; //dandy
		GameInventory.item7num = 0; //lemon
		GameInventory.item8num = 0; //mushroom
		GameInventory.item9num = 0; //saltrock
		GameInventory.item10num = 0; //shell
		GameInventory.item11num = 0; //sugar

		GameInventory.cooked1num = 0; //applepie
		GameInventory.cooked2num = 0; //lemonsquare
		GameInventory.cooked3num = 0; //forest feast
		GameInventory.cooked4num = 0; //carrot cake
		GameInventory.cooked5num = 0; //steak dinner
		GameInventory.cooked6num = 0; //SUPER SLICE
		
		//reset furniture
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
