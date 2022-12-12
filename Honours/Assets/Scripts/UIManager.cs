using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public Transform p1;
    public TextMeshProUGUI infoOutBox; 
    public Player plr; 

    //Buttons
    public GameObject continueBtn; 

    private bool check1 = false; 
    private bool check2 = false; 
    private bool check3 = false; 

    // Start is called before the first frame update
    void Start()
    {
        GameObject p = GameObject.Find("Player"); 
        plr = p.GetComponent<Player>(); 

        infoOutBox.text = " "; 
        p1 = GameObject.Find("Player").transform; 

        //Functional
        continueBtn.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Functional
        if(SceneManager.GetActiveScene().buildIndex == 1){
            if((p1.position.x > -2 && p1.position.x < 12) && plr.coinScore < 2){
                infoOutBox.text = "Move left with A. Move right with D. Jump with Space"; 
            }
            if((p1.position.x > 12 && p1.position.x < 22) && plr.coinScore < 2){
                infoOutBox.text = "Collect the coins"; 
            }
            if(p1.position.x > 22 && p1.position.x < 30){
                infoOutBox.text = "Hit the red box to exit"; 
            }
        }

        //Half-broken
        if(SceneManager.GetActiveScene().buildIndex == 2){
            if(check1 == false){
                Pause(); 
                continueBtn.SetActive(true); 
                infoOutBox.text = "Get to the end and collect coins on the way"; 
            }
        }

        //Broken
        if(SceneManager.GetActiveScene().buildIndex == 3){
            Debug.Log("First Check");
            if(check2 == false && p1.position.x > 15){
                Pause(); 
                continueBtn.SetActive(true); 
                infoOutBox.text = "Remember to collect the coins"; 
            }

            if(check2 == true && check3 == false && p1.position.x > 12){
                Debug.Log("Second Check"); 
                Pause(); 
                continueBtn.SetActive(true); 
                infoOutBox.text = "Hit the red box to exit";
            }
        }
    }

    private void Pause(){
        Time.timeScale = 0.0f;
    }

    public void Continue(){
        Time.timeScale = 1.0f;
        if(SceneManager.GetActiveScene().buildIndex == 2){
            check1 = true; 
            infoOutBox.text = " "; 
            continueBtn.SetActive(false);
        }
        if(SceneManager.GetActiveScene().buildIndex == 3){
            if(check2 == true){
                check3 = true; 
            }
            if(check2 == false){
                check2 = true; 
            }
            continueBtn.SetActive(true);
        }
    }
}
