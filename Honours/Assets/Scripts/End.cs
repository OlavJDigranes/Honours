using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    public SimpleStartManager ssm; 
    
    private void Start() {
        GameObject startMenu = GameObject.Find("StartMenu"); 
        ssm = startMenu.GetComponent<SimpleStartManager>(); 
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            Debug.Log("END"); 
            ssm.End(); 
            if(SceneManager.GetActiveScene().buildIndex == 1){
                SceneManager.LoadScene(4); 
            }
            if(SceneManager.GetActiveScene().buildIndex == 2){
                SceneManager.LoadScene(5);
            }
            if(SceneManager.GetActiveScene().buildIndex == 3){
                SceneManager.LoadScene(6);
            }
        }
    }
}
