using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetingSystemCollider : MonoBehaviour
{
    private Beck beck;

    private void Awake()
    {
        beck = GetComponent<Beck>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Enemy>(out Enemy enemy))
        {
            beck.SetTarget(enemy);
                Debug.Log("Target!");

                //attacks 


        }

    }
}
