using UnityEngine;
using UnityEngine.SceneManagement;


public class StartGame : MonoBehaviour
{
    public void StartButton()
    {
        SceneManager.LoadScene("MainGameScene");
    }
}
