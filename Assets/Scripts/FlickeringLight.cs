using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickeringLight : MonoBehaviour

{
     SpriteRenderer testLight;
     public float minWaitTime;
     public float maxWaitTime;
    
    // Start is called before the first frame update
    void Start()
    {
        testLight = GetComponent<SpriteRenderer>();
        StartCoroutine(Flashing());
    }

    IEnumerator Flashing()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minWaitTime,maxWaitTime));
            testLight.enabled = !testLight.enabled;
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
