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
        wave.velocity = new Vector2(speed, 0);

    }
    void DestroyGameObject()
    {
        Destroy(Player.PlayerReference);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            DestroyGameObject();
        }
    }
}
