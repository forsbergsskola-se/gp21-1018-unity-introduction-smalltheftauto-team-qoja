using UnityEngine;

public class PauseMenu : MonoBehaviour 
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject instructionUI;
    
    void Update()
    {
        if (!instructionUI.activeInHierarchy && !pauseMenuUI.activeInHierarchy && Time.timeScale == 0)
        {
            Resume();
        }
        
        // Press Esc to open the pause menu and the game is paused
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        instructionUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        AudioListener.pause = false;
    }

    public void LoadInstruction()
    {
        pauseMenuUI.SetActive(false);
        instructionUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        AudioListener.pause = true;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        instructionUI.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
        AudioListener.pause = true;
    }
}
