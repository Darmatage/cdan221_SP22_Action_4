using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour{

  public float moveSpeed = 2f;

  public Rigidbody2D rb;
  public Animator animator;
  public GameHandler gameHandler;
  public bool losingStamina = false;
  public int damage = 1;
  public float damageTime = 1f;
  public float timer = 0;

  Vector2 movement;

  void Start(){
    gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();


  }

    void Update()
    {
//input
      movement.x = Input.GetAxisRaw("Horizontal");
      movement.y = Input.GetAxisRaw("Vertical");

      animator.SetFloat("Horizontal", movement.x);
      animator.SetFloat("Vertical", movement.y);
      animator.SetFloat("Speed", movement.sqrMagnitude);

      if((Input.GetAxisRaw("Horizontal")!= 0)||(Input.GetAxisRaw("Vertical")!= 0)){
        losingStamina = true;

      }
      else{losingStamina= false;
      }
    }

    void FixedUpdate(){
      rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

      if(losingStamina == true){
        timer += 0.01f;
        if(timer >= damageTime){
          timer = 0;
          gameHandler.playerGetHit(damage);
          Debug.Log("player lost stamina");
        }

      }
    }
}
