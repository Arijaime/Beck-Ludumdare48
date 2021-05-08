using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class Beck : MonoBehaviour
{
    public Vector2 JumpForce;
    private Enemy targetEnemy;
    private bool active = false;
    
    //Enemies GameObjects
    private GameObject enemyRED;
    private GameObject enemyYELLOW;
    private GameObject enemyPURPLE;
    
    
    public bool createMode;
    public GameObject n;
    
    //Sound Variables 
    public AudioSource swordSound;
    public AudioSource kickSound;
    public AudioSource shurikenSound;
    public AudioSource deathSound;
    
    // Attacks Variables
    public Sprite BeckIddle;
    public Sprite ShurikenAttack;
    public Sprite SwordAttack;
    public Sprite KickAttack;
    
    // Kanjis Variables 
    public Sprite KanjiRojo;
    public Sprite KanjiAmarillo;
    public Sprite KanjiPurpura;
    
    // Spectres Variables
    public Sprite RedSpectreIMG;
    public Sprite YellowSpectreIMG;
    public Sprite PurpleSpectreIMG;
    
    //Score Variable
    public int score;
    public Text TXTscore;

    //public Vector2 SideFoce;
    // -- I choose made with delta time instead force
    void Start()
    {
       
        
    }

    void Update()
    {
        TXTscore.text = "Score : " + score;
        
        // -- Movements --!
        if (Input.GetKeyDown(KeyCode.Space))
        {
            score += 27;
            GetComponent<Rigidbody2D>().AddForce(JumpForce);
        }
        if (Input.GetKeyDown(KeyCode.A)&transform.position.x> -8.0)
        {
            score += 11;
           // GetComponent<Rigidbody2D>().AddForce(JumpForce);
           transform.Translate(Vector2.left*(Time.deltaTime * 100 ));
        }
        if (Input.GetKeyDown(KeyCode.D)& transform.position.x< 8)
        {
            score += 11;
          //  GetComponent<Rigidbody2D>().AddForce(-JumpForce);
          transform.Translate(Vector2.right*(Time.deltaTime * 100 ));
        }

        // ----- create mode? was a crazy test --

      /*  if (createMode )
        
            if (Input.GetKeyDown(KeyCode.Q))
                if (Input.GetKeyDown(KeyCode.Q))
                    Instantiate(n, transform.position, quaternion.identity);
            
        }
        else
        {*/
        
            //    -    -    -    -    -     A T T A C K S -    -    -    -    -
      
            if ((Input.GetKeyDown(KeyCode.Q)&&active) && enemyRED)
            {
                // animation & collider Disable
                score += 1200;
               this.gameObject.GetComponent<SpriteRenderer>().sprite = ShurikenAttack;
               this.gameObject.GetComponent<PolygonCollider2D>().enabled = false;
               
               // ----- -----  In red Spectre Case  --- --- ------------
               enemyRED.gameObject.GetComponent<SpriteRenderer>().sprite = KanjiRojo;
               StartCoroutine(WaitingTime());
               StartCoroutine(WaitingTimeRedSpectre());
               
                shurikenSound.Play();
                
            }
            
            else if ((Input.GetKeyDown(KeyCode.W)&&active) && enemyYELLOW)
            {
                
                score += 2000;
                // animation & collider Disable
              
                this.gameObject.GetComponent<SpriteRenderer>().sprite = SwordAttack;
                this.gameObject.GetComponent<PolygonCollider2D>().enabled = false;
               
                // ----- -----  In yellow Spectre Case  --- --- ------------
                enemyYELLOW.gameObject.GetComponent<SpriteRenderer>().sprite = KanjiAmarillo;
                StartCoroutine(WaitingTime());
                StartCoroutine(WaitingTimeYellowSpectre());
                
                
                swordSound.Play();
                

            }
            
            else if ((Input.GetKeyDown(KeyCode.E)&&active) && enemyPURPLE)
            {
                score += 1300;
                // animation & collider Disable
              
                this.gameObject.GetComponent<SpriteRenderer>().sprite = KickAttack;
                this.gameObject.GetComponent<PolygonCollider2D>().enabled = false;
               
                // ----- -----  In purple Spectre Case  --- --- ------------
                enemyPURPLE.gameObject.GetComponent<SpriteRenderer>().sprite = KanjiPurpura;
                StartCoroutine(WaitingTime());
                StartCoroutine(WaitingTimePurpleSpectre());
                
               
                kickSound.Play();
                

            }
            
        

        

    }
    // --- Enemies capture
    private void OnTriggerEnter2D(Collider2D col)
    {
        active = true;
        if (col.CompareTag("EnemyRED"))
        {
            enemyRED = col.gameObject;
        }
        
        if (col.CompareTag("EnemyYELLOW"))
        {
            enemyYELLOW = col.gameObject;
        }
        
        if (col.CompareTag("EnemyPURPLE"))
        {
            enemyPURPLE = col.gameObject;
        }
        
    }
    
    
    
    private void OnTriggerExit2D(Collider2D col)
    {
        active = false;
    }


    public void SetTarget(Enemy targetEnemy)
    {
        this.targetEnemy = targetEnemy;
    }

    IEnumerator WaitingTime()
    {
        yield return new WaitForSeconds((float) 0.15);
        Debug.Log("Posse");
        this.gameObject.GetComponent<SpriteRenderer>().sprite = BeckIddle;
        StartCoroutine(ColliderProtection());
    }

    IEnumerator WaitingTimeRedSpectre()
    {
        yield return new WaitForSeconds(1);
        Debug.Log("Spectre --> dead");
        enemyRED.gameObject.GetComponent<SpriteRenderer>().sprite = RedSpectreIMG;
        enemyRED.gameObject.GetComponent<PolygonCollider2D>().enabled = true;
        
        enemyRED.transform.position+= new Vector3(0,13,0);
        active = false;
        
    }
    
    IEnumerator WaitingTimeYellowSpectre()
    {
        yield return new WaitForSeconds(1);
        Debug.Log("Spectre --> dead");
        enemyYELLOW.gameObject.GetComponent<SpriteRenderer>().sprite = YellowSpectreIMG;
        enemyYELLOW.gameObject.GetComponent<PolygonCollider2D>().enabled = true;
        
        enemyYELLOW.transform.position+= new Vector3(0,13,0);
        active = false;
        
    }
    
    IEnumerator WaitingTimePurpleSpectre()
    {
        yield return new WaitForSeconds(1);
        Debug.Log("Spectre --> dead");
        enemyPURPLE.gameObject.GetComponent<SpriteRenderer>().sprite = PurpleSpectreIMG;
        enemyPURPLE.gameObject.GetComponent<PolygonCollider2D>().enabled = true;
        
        enemyPURPLE.transform.position+= new Vector3(0,13,0);
        active = false;
        
    }

    IEnumerator ColliderProtection()
    {
        yield return new WaitForSeconds(2);
        this.gameObject.GetComponent<PolygonCollider2D>().enabled = true;

    }
    






}
