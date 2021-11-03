using UnityEngine.SceneManagement;
using UnityEngine;

public class RestartGame : MonoBehaviour
{
    public void LoadGame()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
