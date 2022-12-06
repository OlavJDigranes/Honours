using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI infoOutBox; 
    // Start is called before the first frame update
    void Start()
    {
        infoOutBox.text = " "; 
    }

    // Update is called once per frame
    void Update()
    {
        //Functional
        if(SceneManager.GetActiveScene().buildIndex == 1){
            
        }

        //Half-broken
        if(SceneManager.GetActiveScene().buildIndex == 2){

        }

        //Broken
        if(SceneManager.GetActiveScene().buildIndex == 3){

        }
    }
}
