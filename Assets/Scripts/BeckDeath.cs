using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeckDeath : MonoBehaviour
{
   
   

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y >6.20f)
        {
            SceneManager.LoadScene(0);
        }
        
        if (transform.position.y <-9.2f)
        {
            SceneManager.LoadScene(0);
        }
        
        
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        SceneManager.LoadScene(0);
    }
}
