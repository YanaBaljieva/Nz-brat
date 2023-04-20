using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    public float maxHealth;
    [SerializeField] private Image healthBar;
    [SerializeField] private GameObject deathScreen;
    
    void Start()
    {
        health = maxHealth;
    }
    
    void Update()
    {
        healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);
        if(health <= 0)
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
