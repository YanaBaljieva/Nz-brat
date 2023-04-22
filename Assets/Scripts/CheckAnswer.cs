using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class CheckAnswer : MonoBehaviour
{
    public float correctAnswer;
    public TMP_InputField inputField;
    [SerializeField] private GameObject deathScreen;
    public Button btnClick;

    private void Start()
    {    
        btnClick.onClick.AddListener(checkAnswer);
    }

    public void checkAnswer()
    {
        string answerString = inputField.text;
        float playerAnswer = float.Parse(answerString);

        if (playerAnswer == correctAnswer)
        {
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
        else
        {
            Death();
        }
    }

    void Death()
    {
        deathScreen.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

}
