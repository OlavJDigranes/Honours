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
    public Manager manager; 

    private float timer; 
    private int seconds; 
    private bool scene3Check = false; 
    private AudioSource btnClick; 
    
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0.0f;   
        timer = 0.0f;
        seconds = 0; 

        GameObject empty = GameObject.Find("Manager"); 
        manager = empty.GetComponent<Manager>();

        GameObject p = GameObject.Find("Player"); 
        plr = p.GetComponent<Player>(); 

        if(SceneManager.GetActiveScene().buildIndex == 1){
            btnClick = GetComponent<AudioSource>();
        }
    }

    private void Update() {
        timer += Time.deltaTime; 
        float sec = timer % 60;
        seconds = (int)sec; 
        if(SceneManager.GetActiveScene().buildIndex == 3 && Input.GetKeyDown(KeyCode.Escape) && scene3Check == false){
            menuPanel.SetActive(false);
            scene3Check = true; 
        }
    }

    public void Run(){
        Time.timeScale = 1.0f;
        if(SceneManager.GetActiveScene().buildIndex != 3){
            menuPanel.SetActive(false); 
        }
        if(SceneManager.GetActiveScene().buildIndex == 1){
            btnClick.Play(); 
        }
    }

    public void End(){
        manager.dataWriter.WriteLine(seconds + "," + plr.coinScore + "," + SceneManager.GetActiveScene().buildIndex); 
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
