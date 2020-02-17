﻿using System.Collections;
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
        speed = Player.speed - Player.boost;
        wave.velocity = new Vector2(speed, 0);

    }
   
}
