using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 15;
    private Rigidbody2D myRigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        Fire();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Fire() {
        myRigidbody2D.velocity = Vector2.down * speed; 
    }

    private void OnTriggerEnter2D (Collider2D collision) {
        if (collision.CompareTag("Player")) {
            Debug.Log("Player hit");
            FindObjectOfType<UI>().minusLife();
            Destroy(this.gameObject);
        }
        if (collision.CompareTag("Shield")) {
            Debug.Log("Shield hit");
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
        if (collision.CompareTag("Wall")) {
            Destroy(this.gameObject);
        }
    }
}
