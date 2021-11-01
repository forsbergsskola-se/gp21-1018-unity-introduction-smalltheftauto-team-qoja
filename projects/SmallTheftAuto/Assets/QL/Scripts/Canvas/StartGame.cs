using UnityEngine.SceneManagement;
using UnityEngine;

public class StartGame : MonoBehaviour
{
   public void LoadGame()
   {
      SceneManager.LoadScene("GameQL");
   }
}
