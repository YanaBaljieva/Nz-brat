using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootingBlade : MonoBehaviour
{
    public int damage;
    public float speed;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")){
            other.GetComponent<PlayerHealth>().health -= damage;
        }
    }
}
