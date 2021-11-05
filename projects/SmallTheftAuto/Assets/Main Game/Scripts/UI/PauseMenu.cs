using UnityEngine;

public class PauseMenu : MonoBehaviour 
{
    private static bool _gameIsPaused = false;
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
            if (_gameIsPaused)
            {
                if (instructionUI.activeInHierarchy)
                {
                    Pause();
                }
                else
                {
                    Resume();
                }
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
        _gameIsPaused = false;
        AudioListener.pause = false;
    }

    public void LoadInstruction()
    {
        pauseMenuUI.SetActive(false);
        instructionUI.SetActive(true);
        Time.timeScale = 0f;
        _gameIsPaused = true;
        AudioListener.pause = true;
    }

    private void Pause()
    {
        pauseMenuUI.SetActive(true);
        instructionUI.SetActive(false);
        _gameIsPaused = true;
        Time.timeScale = 0f;
        AudioListener.pause = true;
    }
}
