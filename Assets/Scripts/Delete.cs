using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delete : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        
        if (collision.gameObject.tag == "Deleter")
        {

            Destroy(this.gameObject);

        }
        
    }
}
