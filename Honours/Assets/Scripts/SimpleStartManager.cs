using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SimpleStartManager : MonoBehaviour
{
    public GameObject menuPanel; 
    public Player plr; 

    private string path;
    private StreamWriter writer;
    private float timer; 
    private int seconds; 
    
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0.0f;   
        timer = 0.0f;
        seconds = 0; 

        path = getPath();
        writer = new StreamWriter(path);
        writer.WriteLine("Time(S),CoinScore,LevelID"); 

        GameObject p = GameObject.Find("Player"); 
        plr = p.GetComponent<Player>(); 
    }

    private void Update() {
        timer += Time.deltaTime; 
        float sec = timer % 60;
        seconds = (int)sec; 
    }

    public void Run(){
        Time.timeScale = 1.0f; 
        menuPanel.SetActive(false); 
    }

    public void End(){
        writer.WriteLine(seconds + "," + plr.coinScore + "," + SceneManager.GetActiveScene().buildIndex); 
        writer.Flush();
        writer.Close();
    }

    //https://forum.unity.com/threads/write-data-from-list-to-csv-file.643561/
    private string getPath()
    {
#if UNITY_EDITOR
        return Application.dataPath + "/Data/"  + "Data.csv";
#else
        return Application.dataPath +"/"+"Data.csv";
#endif
    }
}
