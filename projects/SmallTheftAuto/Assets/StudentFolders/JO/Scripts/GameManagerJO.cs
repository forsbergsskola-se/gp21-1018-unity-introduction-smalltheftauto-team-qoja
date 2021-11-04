using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerJO : MonoBehaviour
{
    public static void RestartGame() {
        SceneManager.LoadScene("JO/Scenes/GameJO");
    }
}
