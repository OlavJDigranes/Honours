using System; 
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    //https://forum.unity.com/threads/randomize-scene-without-repeating.650182/
    public GameObject manager; 
    public List<int> availableScenes;
    public List<int> playedScenes;

    private int counter = 0; 

    private string dataPath;
    public StreamWriter dataWriter;

    public string GDPR; 
    public string level1Data; 
    public string level2Data; 
    public string level3Data; 
    public string level1PlrData; 
    public string level2PlrData; 
    public string level3PlrData; 

    //private string qDataPath;
    //public StreamWriter qDataWriter;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(manager); 
        for(int i = 1; i < 4; i++){
            availableScenes.Add(i); 
        }

        dataPath = getDataPath();
        dataWriter = new StreamWriter(dataPath, true);
        dataWriter.WriteLine("GDPR_PERM_1,GDPR_PERM_2,GDPR_PERM_3,Time(S)_1,CoinScore_1,A_Pressed_1,D_Pressed_1,Space_Pressed_1,ESC_Pressed_1,Q1_1,Q2_1,Q3_1,Time(S)_2,CoinScore_2,A_Pressed_2,D_Pressed_2,Space_Pressed_2,ESC_Pressed_2,Q1_2,Q2_2,Q3_2,Time(S)_3,CoinScore_3,A_Pressed_3,D_Pressed_3,Space_Pressed_3,ESC_Pressed_3,Q1_3,Q2_3,Q3_3"); 

        //qDataPath = getQDataPath();
        //qDataWriter = new StreamWriter(qDataPath, true);
        //qDataWriter.WriteLine("Q1,Q2,Q3,ForScene"); 

        SceneManager.LoadScene(8);
    }

    public void LoadNextScene(){
        //Safety
        counter++; 
        if (availableScenes.Count < 1) {
            SceneManager.LoadScene(7); 
        }
        int index = UnityEngine.Random.Range(0, availableScenes.Count);
        Debug.Log(index); 
        if(counter <= 3){
            int theSceneIndex = availableScenes[index]; // Access Scene
            availableScenes.RemoveAt(index);
            playedScenes.Add(theSceneIndex);
            SceneManager.LoadScene(theSceneIndex);
        } 
    }

    //https://forum.unity.com/threads/write-data-from-list-to-csv-file.643561/
    private string getDataPath()
    {
#if UNITY_EDITOR
        return Application.dataPath + "/Data/"  + "Data.csv";
#else
        return Application.dataPath +"/"+"Data.csv";
#endif
    }

    private string getQDataPath()
    {
#if UNITY_EDITOR
        return Application.dataPath + "/Data/"  + "QuestionnaireData.csv";
#else
        return Application.dataPath +"/"+"QuestionnaireData.csv";
#endif
    }
}
