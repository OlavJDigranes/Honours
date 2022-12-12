using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    public Manager manager; 

    private void Start() {
        GameObject empty = GameObject.Find("Manager"); 
        manager = empty.GetComponent<Manager>();
    }

    public void ExitFunction(){
        Debug.Log("EXIT");
        
        manager.qDataWriter.Flush();
        manager.qDataWriter.Close(); 

        manager.dataWriter.Flush(); 
        manager.dataWriter.Close(); 

        Application.Quit(); 
    }
}
