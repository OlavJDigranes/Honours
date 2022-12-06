using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    GameObject player; 
    float speed = 10.0f; 
    float jump = 5.0f; 
    float moveVel; 
    bool canJump; 
    public int coinScore = 0; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Movevment
        moveVel = 0;

        if(player.transform.position.y < -5){
            ResetPlayer(); 
        }

        //Left Right Movement
        if (Input.GetKey(KeyCode.A)) 
        {
            moveVel = -speed;
        }
        if (Input.GetKey(KeyCode.D)) 
        {
            moveVel = speed;
        }

        GetComponent<Rigidbody2D>().velocity = new Vector2(moveVel, GetComponent<Rigidbody2D>().velocity.y);

        //Jumping
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            if(canJump)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jump);
                canJump = false; 
            }
        }
    }

    private void ResetPlayer(){
        player.transform.position = Vector3.zero; 
        GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 0.0f); 
    }

    private void OnCollisionEnter2D(Collision2D col) {
        if(col.gameObject.tag == "Collidable"){
            canJump = true; 
        }
    }

    private void OnTriggerEnter2D(Collider2D coin) {
        if(coin.gameObject.tag == "Coin"){
            coinScore++;  
        }
    }
}
