using System; 
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; 

public class RecordQuestionnaire : MonoBehaviour
{
    public Manager manager; 
    public TMP_Dropdown input1; 
    public TMP_Dropdown input2; 
    public TMP_Dropdown input3; 

    // Start is called before the first frame update
    void Start()
    {
        GameObject empty = GameObject.Find("Manager"); 
        manager = empty.GetComponent<Manager>(); 
    }

    public void RecordData(){
        manager.qDataWriter.WriteLine((input1.value + 1) + "," + (input2.value + 1) + "," + (input3.value + 1) + "," + (SceneManager.GetActiveScene().buildIndex - 3)); 
        manager.LoadNextScene(); 
    }

    //https://forum.unity.com/threads/write-data-from-list-to-csv-file.643561/
    private string getPath()
    {
#if UNITY_EDITOR
        return Application.dataPath + "/Data/"  + "QuestionnaireData.csv";
#else
        return Application.dataPath +"/"+"QuestionnaireData.csv";
#endif
    }
}
