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
      }

      public void RestartGame() {
            Time.timeScale = 1f;
            SceneManager.LoadScene("MainMenu");
            playerStamina = StartPlayerStamina;
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
}
