using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] Canvas gameOverScreen;

    // Start is called before the first frame update
    void Start()
    {
        gameOverScreen.enabled = false;
    }

    public void HandleDeath(){
        gameOverScreen.enabled = true;
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
