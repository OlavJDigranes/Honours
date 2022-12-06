using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float speed = 10.0f; 
    float jump = 5.0f; 
    float moveVel; 
    bool canJump; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Movevment
        moveVel = 0;

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
                GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D>().velocity.x, jump);
                canJump = false; 
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D col) {
        if(col.gameObject.tag == "Collidable"){
            canJump = true; 
        }
    }
}
