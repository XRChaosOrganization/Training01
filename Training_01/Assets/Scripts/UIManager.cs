using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject gameCanvas;
    public GameObject pauseMenu;
    public bool isGamePausable;
    public GameObject levelContainer;

    public void Update()
    {
        if (Input.GetKey(KeyCode.Space) && isGamePausable == true)
        {
            Time.timeScale = 0;
            PauseGame();
        }
    }

    public void InitGame()
    {
        Instantiate(levelContainer);
    }

    public void PauseGame()
    {
        gameCanvas.SetActive(true);
        pauseMenu.SetActive(true);
    }
    
    public void ResumeGame()
    {
        Time.timeScale = 1;
        gameCanvas.SetActive(false);
        pauseMenu.SetActive(false);
    }
    
   
}
