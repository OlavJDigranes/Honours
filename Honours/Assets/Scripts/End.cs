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

    private void OnCollisionEnter2D(Collision2D other) {
        ssm.End(); 
    }
}
