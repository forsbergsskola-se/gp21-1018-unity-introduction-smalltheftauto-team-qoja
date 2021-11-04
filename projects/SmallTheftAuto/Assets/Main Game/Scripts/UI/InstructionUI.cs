using UnityEngine;

public class InstructionUI : MonoBehaviour
{
    public GameObject pauseMenuUI;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenuUI.GetComponent<PauseMenu>().Pause();
        }
    }
}
