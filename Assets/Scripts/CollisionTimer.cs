using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionTimer : MonoBehaviour
{
    private float duration = 0.0f;
    [SerializeField] private GameObject deathScreen;

    void OnCollisionStay2D(Collision2D collision)
    {
        duration += Time.deltaTime;
        Debug.Log(duration);
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        Timer();
    }

    public void Timer()
    {
        if ((duration > 3) && (duration < 10))
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
            //change vitanov sprite
            Death();

        }
    }

    void Death()
    {
        deathScreen.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }
}