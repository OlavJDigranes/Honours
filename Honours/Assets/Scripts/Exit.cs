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
        
        //manager.qDataWriter.Flush();
        //manager.qDataWriter.Close(); 
        
        manager.dataWriter.WriteLine(manager.GDPR + "," + manager.level1PlrData + "," + manager.level1Data + "," + manager.level2PlrData + "," + manager.level2Data + "," + manager.level3PlrData + "," + manager.level3Data + "," + manager.level3TenSecondCheck + "," + manager.playedScenes[0] + "," + manager.playedScenes[1] + "," + manager.playedScenes[2]); 
        manager.dataWriter.Flush(); 
        manager.dataWriter.Close(); 

        Application.Quit(); 
    }
}
