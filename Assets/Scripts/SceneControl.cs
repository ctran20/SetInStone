using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
    [SerializeField] private GameObject menu;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            menu.SetActive(!menu.activeSelf);
        }
    }

    public void StartOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadNextScene()
    {
        if (SceneManager.sceneCountInBuildSettings == SceneManager.GetActiveScene().buildIndex + 1)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void MainMenu()
    {
        Destroy(GameObject.FindWithTag("Music"));
        SceneManager.LoadScene(0);
    }

    private void Destroy(GameObject[] gameObject)
    {
        throw new NotImplementedException();
    }

    public void Quit()
    {
        Application.Quit();
    }
}
