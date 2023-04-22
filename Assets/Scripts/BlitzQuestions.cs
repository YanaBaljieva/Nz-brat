using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BlitzQuestions : MonoBehaviour
{
    public string answer;
    public Button btnClick;
    [SerializeField] private GameObject deathScreen;

      private void Start()
      {
         btnClick.onClick.AddListener(checkAnswer);
      }
    public bool isCorrect = false;

    


    public void checkAnswer()
    {
        //if(btnClick.GetComponentInChildren<>() == true)
       // {
            while (true)
            {

                int random = Random.Range(1, SceneManager.sceneCountInBuildSettings);
                if (random != SceneManager.GetActiveScene().buildIndex)
                {
                    SceneManager.LoadScene(random);
                    break;
                }
            }
        }
      //  else
      //  {
       //     Death();
       // }
    //}

    void Death()
    {
        deathScreen.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }
}
