using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   void Start()
    {
        Destroy(GameObject.FindWithTag("Music1"));
        Destroy(GameObject.FindWithTag("Music2"));
        Destroy(GameObject.FindWithTag("Music3"));
        Destroy(GameObject.FindWithTag("Data"));
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void LoadGame()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadSandbox()
    {
        SceneManager.LoadScene(2);
    }
}
