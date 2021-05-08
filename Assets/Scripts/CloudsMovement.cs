using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudsMovement : MonoBehaviour
{
    public float speed;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime *speed);
        if (transform.position.x < -11)
        {
            transform.position+= new Vector3(23,0,0);
            ShowRandomClouds();
        }
    }

    private void ShowRandomClouds()
    {
        int randomNum = UnityEngine.Random.Range(0,3);
        
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            bool showChild = randomNum == i;
            
            child.gameObject.SetActive(showChild);

        }
    }

    private void OnEnable()
    {
        ShowRandomClouds();
    }
}
