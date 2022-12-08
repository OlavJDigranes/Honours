using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    //https://forum.unity.com/threads/randomize-scene-without-repeating.650182/
    public GameObject manager; 
    public List<int> availableScenes;
    public List<int> playedScenes;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(manager); 
        for(int i = 1; i < 4; i++){
            availableScenes.Add(i); 
        }
        LoadNextScene();
    }

    public void LoadNextScene(){
        int index = UnityEngine.Random.Range(0, availableScenes.Count);
        int theSceneIndex = availableScenes[index]; // Access Scene
        availableScenes.RemoveAt(index);
        playedScenes.Add(theSceneIndex);

        //Safety
        if (availableScenes.Count < 1) {
            SceneManager.LoadScene(7); 
        }

        SceneManager.LoadScene(theSceneIndex); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
