using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    public float minSpeed;
    public static float maxSpeed;
    public float speed;
    public float jump;
    public bool jumpOnce = false;
    public static bool onGround = true;
    public Rigidbody2D player;
    public Transform targetPos;
    public static Rigidbody2D PlayerReference;

    // Start is called before the first frame update
    void Start()
    {
        maxSpeed = 10;
        PlayerReference = player;
    }

    // Update is called once per frame
    void Update()
    {
        #region Movement
        if (Input.GetKey(KeyCode.RightArrow) && speed < maxSpeed)
        {
            speed = speed + 1;
        }
        if (Input.GetKey(KeyCode.LeftArrow) && speed > minSpeed)
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

        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            onGround = false;
            //player = player.velocity.y +jump;
            if (player.transform.position.y < targetPos.position.y)
            {
                //player.transform.position = Vector2.MoveTowards(player.transform.position, targetPos.position, jump * Time.deltaTime);
                player.velocity = new Vector2(speed, jump);
            }

            jumpOnce = true;
        }

        if (Input.GetKeyDown(KeyCode.Space) && jumpOnce)
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

        if (player.transform.position.y >= targetPos.position.y)
        {
            //player.velocity = new Vector2(speed, -jump);

        }

        #endregion

        

    }
        

}
