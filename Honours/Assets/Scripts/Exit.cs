using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    public void ExitFunction(){
        Debug.Log("EXIT");
        Application.Quit(); 
    }
}
