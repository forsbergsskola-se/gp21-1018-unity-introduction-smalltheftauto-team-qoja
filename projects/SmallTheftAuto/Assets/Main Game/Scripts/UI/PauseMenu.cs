using UnityEngine;

public class PauseMenu : MonoBehaviour 
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject instructionUI;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                if(instructionUI.activeInHierarchy)
                    Pause();
                else
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
    }

    public void LoadInstruction()
    {
        pauseMenuUI.SetActive(false);
        instructionUI.SetActive(true);
        Time.timeScale = 1f;
        GameIsPaused = true;
    }

    private void Pause()
    {
        pauseMenuUI.SetActive(true);
        instructionUI.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
}
