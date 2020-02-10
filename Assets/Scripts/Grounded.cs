using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounded : MonoBehaviour
{
    public bool died;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wave")
        {
            died = true;
        }
            if (collision.gameObject.tag == "Ground")
        {
            Player.onGround = true;
            Invoke("ResetFriction", 1.5f);

        }
        if (collision.gameObject.tag == "Damage")
        {
            Player.PlayerReference.sharedMaterial.friction = 1f;
            Destroy(collision.gameObject);
            Player.maxSpeed = Player.maxSpeed - 1;
        }

    }
    public void ResetFriction()
    {
        //Player.PlayerReference.sharedMaterial.friction = 0f;
    }
}
