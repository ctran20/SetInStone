using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameManager : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    bool paused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseTrigger();
        }
    }
    public void LoadMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    public void PauseTrigger()
    {
        if (paused)
        {
            paused = false;
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
            FindObjectOfType<WeaponSwitcher>().enabled = true;
            FindObjectOfType<Weapon>().enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            paused = true;
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
            FindObjectOfType<WeaponSwitcher>().enabled = false;
            FindObjectOfType<Weapon>().enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
