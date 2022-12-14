using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GDPR : MonoBehaviour
{
    public Manager manager; 
    public GameObject continueBtn; 
    public GameObject exitBtn; 

    private bool check1 = false;
    private bool check2 = false; 
    private bool check3 = false; 

    void Start()
    {
        GameObject empty = GameObject.Find("Manager"); 
        manager = empty.GetComponent<Manager>();
    }

    public void GDPRCheck1(){
        check1 = !check1; 
        Debug.Log("Check1, " + check1);        
        RevealButton();
    }

    public void GDPRCheck2(){
        check2 = !check2; 
        Debug.Log("Check2, " + check2);
        RevealButton();
    }

    public void GDPRCheck3(){
        check3 = !check3; 
        Debug.Log("Check3, " + check3);
        RevealButton();
    }

    private void RevealButton(){
        Debug.Log("BTN REVEAL?" + ", " + check1 + ", " + check2 + ", " + check3);
        if(check1 == true && check2 == true && check3 == true){
            Debug.Log("BTN REVEAL!");
            exitBtn.SetActive(false); 
            continueBtn.SetActive(true); 
        }
        else{
            exitBtn.SetActive(true); 
            continueBtn.SetActive(false);
        }
    }

    public void CommenceTest(){
        if(check1 == true && check2 == true && check3 == true){
            manager.GDPR = "Yes,Yes,Yes"; 
            manager.LoadNextScene(); 
        }
    }

    public void Exit(){
        Application.Quit(); 
    }
}
