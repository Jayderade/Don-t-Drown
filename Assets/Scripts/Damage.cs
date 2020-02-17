using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{

    public bool test;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Damage")
        {

            
            Player.colObj = true;
            

        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        

        if (collision.gameObject.tag == "Damage")
        {

            
            Player.colObj = false;
            Destroy(collision.gameObject);

        }
    }

    // Update is called once per frame
    void Update()
    {
        test = Player.colObj;
    }
}
