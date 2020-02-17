using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    public float speed;
    private Rigidbody2D wave;

    // Start is called before the first frame update
    void Start()
    {

        wave = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        speed = speed + 0.00001f;
        wave.velocity = new Vector2(speed, 0);

    }
   
}
