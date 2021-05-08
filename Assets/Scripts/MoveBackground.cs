using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] 
    private float moveSpeed = 1f;

    [SerializeField] 
    private float offset;

    private Vector2 startPosition;
    private float newXposition;
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        newXposition = Mathf.Repeat(Time.time * -moveSpeed, offset);

        transform.position = startPosition + Vector2.down * newXposition;

    }
}
