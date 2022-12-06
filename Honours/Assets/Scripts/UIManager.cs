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

    // Start is called before the first frame update
    void Start()
    {
        GameObject p = GameObject.Find("Player"); 
        plr = p.GetComponent<Player>(); 

        infoOutBox.text = " "; 
        p1 = GameObject.Find("Player").transform; 
    }

    // Update is called once per frame
    void Update()
    {
        //Functional
        if(SceneManager.GetActiveScene().buildIndex == 1){
            if((p1.position.x > -2 && p1.position.x < 22) && plr.coinScore < 2){
                infoOutBox.text = "Collect the coins"; 
            }
            if(p1.position.x > 22 && p1.position.x < 30){
                infoOutBox.text = "Hit the red box to exit"; 
            }
        }

        //Half-broken
        if(SceneManager.GetActiveScene().buildIndex == 2){

        }

        //Broken
        if(SceneManager.GetActiveScene().buildIndex == 3){

        }
    }
}
