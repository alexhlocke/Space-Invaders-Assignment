using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour
{
    public float speed = 7;
    private Rigidbody2D myRigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().playSound("spaceship");
        myRigidbody2D = GetComponent<Rigidbody2D>();
        myRigidbody2D.velocity = Vector2.left * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
