using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door_MapReturn : MonoBehaviour {

       public string NextLevel = "MainMenu";
       private string thisLevel;
       private Vector2 doorReturnPos;       // load with location for player when they return
       public float offsetX = 0f;        // distance to left or right of the door for player to spawn
       public float offsetY = -2f;        // distance above or below the door for player to spawn
      
       void Start() {
              thisLevel = SceneManager.GetActiveScene().name;
              doorReturnPos = new Vector2((transform.position.x + offsetX), (transform.position.y + offsetY));
       }

       public void OnTriggerEnter2D(Collider2D other) {
              if (other.gameObject.tag == "Player"){
                            GameHandler_PlayerReturn.lastDoorPosition = doorReturnPos;
                            GameHandler_PlayerReturn.lastMap = thisLevel;
                            SceneManager.LoadScene (NextLevel);
              }
       }
} 