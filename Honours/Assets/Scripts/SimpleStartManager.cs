using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleStartManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0.0f;    
    }

    public void Run(){
        Time.timeScale = 1.0f; 

    }
}
