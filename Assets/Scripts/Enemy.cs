using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
   public float speed;
   public Enemy enemy;
   public Sprite red;
   public Sprite yellow;
   public Sprite purple;


   private void Awake()
   {
      enemy = GetComponent<Enemy>();
   }

   void Update()
   {
      // -- Upper Movement -- !!
      transform.Translate(Vector3.up * Time.deltaTime *speed);
      if (transform.position.y > 13)
      {
         transform.position+= new Vector3(0,-23,0);
         //  ShowRandomClouds();
      }
      
      // -- Load Enemies -- !!
      enemy?.Respawn();
      
      
   }
/*
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
    }*/

   
  public void Death()
   {
      GetComponent<SpriteRenderer>().enabled = false;
      GetComponent<PolygonCollider2D>().enabled = false;
   }

  public void Respawn()
   {
      GetComponent<SpriteRenderer>().enabled = true;
      GetComponent<PolygonCollider2D>().enabled = true;
      
   }

}
