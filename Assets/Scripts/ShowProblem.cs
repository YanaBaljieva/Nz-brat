using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowProblem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int randomIndex = Random.Range(0, transform.childCount + 1);
        transform.GetChild(randomIndex).gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
