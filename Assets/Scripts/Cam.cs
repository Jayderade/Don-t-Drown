using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    public float fast;
    public Rigidbody2D cam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fast = Player.speed;
        cam.velocity = new Vector2(fast + Player.boost, cam.velocity.y);
    }
}
