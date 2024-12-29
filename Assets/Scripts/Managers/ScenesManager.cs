using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public static void LoadGameScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public static void QuitGame()
    {
        Application.Quit();
    }
}
