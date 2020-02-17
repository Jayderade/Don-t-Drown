using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    public float minSpeed;
    public float maxSpeed;
    public float speed;
    public float jump;
    public bool jumpOnce = false;
    public bool onGround = true;
    public bool colObj = false;
    public Rigidbody2D player;
    public Transform targetPos;
    public static Rigidbody2D PlayerReference;
    public Transform feet;
    public Transform frontBody;
    public float checkRadius;
    public LayerMask theGround;
    public LayerMask obstacle;

    // Start is called before the first frame update
    void Start()
    {
        
        PlayerReference = player;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
       /* if (collision.gameObject.tag == "Ground")
        {
            onGround = true;
            Invoke("ResetFriction", 1.5f);
            Debug.Log("W");
        }
        if (collision.gameObject.tag == "Damage")
        {
            Debug.Log("W");
            PlayerReference.sharedMaterial.friction = 1f;
            Destroy(collision.gameObject);
            maxSpeed = maxSpeed - 1;
        }*/

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Wave")
        {
           Destroy(this.gameObject.transform.parent.gameObject);
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        #region Movement
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D) && speed < maxSpeed)
        {
            speed = speed + 1;
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A) && speed > minSpeed)
        {
            speed = speed - 1;
        }
        if (onGround)
        {
            player.velocity = new Vector2(speed, player.velocity.y);
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
            speed = speed - 0.005f;
            
        }
        if (!colObj)
        {
            speed = speed + 0.00001f;

        }
        

        onGround = Physics2D.OverlapCircle(feet.position, checkRadius, theGround);
        
        colObj = Physics2D.OverlapCircle(frontBody.position, checkRadius, obstacle);

    }
        

}
