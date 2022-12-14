using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class Player : MonoBehaviour
{
    [SerializeField]
    GameObject player; 
    float speed = 10.0f; 
    float jump = 5.0f; 
    float moveVel; 
    bool canJump; 
    private AudioSource pling; 

    public int coinScore = 0; 
    public int aData = 0;
    public int dData = 0;
    public int spaceData = 0;
    public int escData = 0;

    // Start is called before the first frame update
    void Start()
    {
        if(SceneManager.GetActiveScene().buildIndex == 1){
            pling = GetComponent<AudioSource>(); 
        }
        coinScore = 0;
        aData = 0;
        dData = 0; 
        spaceData = 0; 
        escData = 0; 
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
            spaceData++; 
        }

        if(Input.GetKeyDown(KeyCode.A)){
            aData++;
        }
        if(Input.GetKeyDown(KeyCode.D)){
            dData++;
        }
        if(Input.GetKeyDown(KeyCode.Escape)){
            escData++;
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
            if(SceneManager.GetActiveScene().buildIndex == 1){
                pling.Play();
            }
        }
    }
}
