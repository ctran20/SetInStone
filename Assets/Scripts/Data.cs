using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour
{
    private static GameObject instance;
    int currentStage = 1;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (instance == null)
        {
            instance = gameObject;
        }
        else
        {
            Destroy(gameObject);
        }

    }

    public int getStage(){
        return currentStage;
    }

    public void setStage(int stage){
        currentStage = stage;
    }
}
