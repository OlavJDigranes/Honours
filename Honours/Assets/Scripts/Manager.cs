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

    private string qDataPath;
    public StreamWriter qDataWriter;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(manager); 
        for(int i = 1; i < 4; i++){
            availableScenes.Add(i); 
        }

        dataPath = getDataPath();
        dataWriter = new StreamWriter(dataPath, true);
        dataWriter.WriteLine("Time(S),CoinScore,LevelID"); 

        qDataPath = getQDataPath();
        qDataWriter = new StreamWriter(qDataPath, true);
        qDataWriter.WriteLine("Q1,Q2,Q3,ForScene"); 

        LoadNextScene();
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
