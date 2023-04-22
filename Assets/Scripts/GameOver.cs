using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void PlayAgain()
    {
        
        while (true) {
            
            int random = Random.Range(1, SceneManager.sceneCountInBuildSettings);
            if (random != SceneManager.GetActiveScene().buildIndex)
            {
                SceneManager.LoadScene(random);
                break;
            }
        }
        
       
        
        Time.timeScale = 1f;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;
    }
}
