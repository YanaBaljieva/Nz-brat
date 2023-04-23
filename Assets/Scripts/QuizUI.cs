using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuizUI : MonoBehaviour
{
    [SerializeField] private QuizManager quizManager;
    [SerializeField] private TMP_Text questionText;
    [SerializeField] private Image questionImage;
    [SerializeField] private List<Button> options;
    [SerializeField] private Color correctCol, wrongCol, normalCol;
    [SerializeField] private GameObject deathScreen;

    private Question question;
    private bool answered;
   
    void Awake()
    {
        for(int i = 0; i < options.Count; i++)
        {
            Button localBtn = options[i];
            localBtn.onClick.AddListener(() => OnClick(localBtn));
        }
    }

    public void SetQuestion(Question question)
    {
        this.question = question;

        switch (question.questionType)
        {
            case QuestionType.TEXT:
                questionImage.transform.gameObject.SetActive(false);
                questionText.transform.gameObject.SetActive(true);
                break;
            case QuestionType.IMAGE:
                ImageHolder();
                questionImage.transform.gameObject.SetActive(true);
                questionText.transform.gameObject.SetActive(true);
                questionImage.sprite = question.questionImg;
                break;
            default:
                break;
        }

        questionText.text = question.questionInfo;
        List<string> answerList = ShuffleList.ShuffleListItems<string>(question.options);
        
        for(int i = 0; i < options.Count; i++)
        {
            options[i].GetComponentInChildren<TMP_Text>().text = answerList[i];
            options[i].name = answerList[i];
            options[i].image.color = normalCol;
        }

        answered = false;
    }

    void ImageHolder()
    {
        questionImage.transform.parent.gameObject.SetActive(true);
        questionImage.transform.gameObject.SetActive(false);

    }

    private void OnClick(Button btn)
    {
        if (!answered)
        {
            answered = true;
            bool val = quizManager.Answer(btn.name);
            if (val)
            {
                btn.image.color = correctCol;
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
                btn.image.color = wrongCol;
                Death();
            }
        }
    }
    void Death()
    {
        deathScreen.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
