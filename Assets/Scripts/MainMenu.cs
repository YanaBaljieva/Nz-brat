using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(Random.Range(1, SceneManager.sceneCount + 1));
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
