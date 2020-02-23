using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
   
    public static float speed;
    public float speedBoost = 1;
    public float jump;
    public float running;
    public static float boost;    
    public bool onBoost = false;
    public bool jumpOnce = false;
    public bool onGround = true;
    public bool bounce = false;
    public static bool died = false;
    public static bool pickUpCoin;
    public static bool colObj = false;
    public Rigidbody2D player;
    public Transform targetPos;
    public static Rigidbody2D PlayerReference;
    public Transform feet;
    public Transform frontBody;
    public float checkRadius;
    public LayerMask theGround;
    public LayerMask boosted;
    public LayerMask tramp;
    public LayerMask coin;

    // Start is called before the first frame update
    void Start()
    {
        boost = 0;
        PlayerReference = player;
        
    }

    

    void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Wave")
        {
           Destroy(this.gameObject.transform.parent.gameObject);
            died = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
       
        #region Movement

        player.velocity = new Vector2(speed, player.velocity.y);
        /* if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D) && speed < maxSpeed)
         {
             speed = speed + 1;
         }
         if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A) && speed > minSpeed)
         {
             speed = speed - 1;
         }*/
        if (onGround)
        {
             
            jumpOnce = false;
        }
        
        //Check if grounded

        //if grounded and key pressed 
        //move up - move towards/ lerp by time or velocity 

        //we are not grounded

        if (Input.GetKeyDown(KeyCode.Space) && jumpOnce && !onGround || Input.GetKeyDown(KeyCode.W) && jumpOnce && !onGround)
        {
            //player = player.velocity.y +jump;
            if (player.transform.position.y < targetPos.position.y)
            {
                //player.transform.position = Vector2.MoveTowards(player.transform.position, targetPos.position, jump * Time.deltaTime);
                player.velocity = new Vector2(speed, jump);
            }
            onGround = false;
            jumpOnce = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && onGround || Input.GetKeyDown(KeyCode.W) && onGround)
        {
            
            onGround = false;
            jumpOnce = true;
            //player = player.velocity.y +jump;
            if (player.transform.position.y < targetPos.position.y)
            {
                //player.transform.position = Vector2.MoveTowards(player.transform.position, targetPos.position, jump * Time.deltaTime);
                player.velocity = new Vector2(speed, jump);
            }

            
        }

       

        if (player.transform.position.y >= targetPos.position.y)
        {
            //player.velocity = new Vector2(speed, -jump);

        }

        #endregion
        
        if(colObj)
        {
           if(running <= 5)
            {
                running = 0;
            }
            if (running <= 10)
            {
                running = 4;
            }
            if (running <= 15)
            {
                running = 7;
            }


        }
        speedBoost = speed;
        
        if(bounce && !onGround)
        {
            if (player.transform.position.y < targetPos.position.y)
            {
                //player.transform.position = Vector2.MoveTowards(player.transform.position, targetPos.position, jump * Time.deltaTime);
                player.velocity = new Vector2(speed, 30);
            }
        }

        if (onBoost)
        {
            boost = 5f;
            
            
                speed = running + boost;
                
            
          
        }
        if(!onBoost && !colObj)
        {
            boost = 0;

           
                speed = running + boost;
                
            
           
        }
        if (running < 15)
        {
            speed = running;
            running += 2 * Time.deltaTime;
            
        }
        if (speed > 15)
        {          
            
            running = 15;
        }
        onGround = Physics2D.OverlapCircle(feet.position, checkRadius, theGround);

        onBoost = Physics2D.OverlapCircle(feet.position, checkRadius, boosted);

        bounce = Physics2D.OverlapCircle(feet.position, checkRadius, tramp);

        pickUpCoin = Physics2D.OverlapCircle(frontBody.position, checkRadius, coin);
    }
        

}
