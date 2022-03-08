using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))] //technique for making sure there isn't a null reference during runtime if you are going to use get component
public class Bullet : MonoBehaviour
{
  private Rigidbody2D myRigidbody2D;

  public float speed = 15;

    // Start is called before the first frame update
    void Start()
    {
      myRigidbody2D = GetComponent<Rigidbody2D>();
      Fire();
    }

    // Update is called once per frame
    private void Fire()
    {
      myRigidbody2D.velocity = Vector2.up * speed; 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Calculate points per enemy
        int pointsToBeAdded = 0;
        if (collision.CompareTag("Enemy1"))
        {
            pointsToBeAdded = 40;
            FindObjectOfType<InvaderManager>().speedUp();
            // Debug.Log("Hit Enemy 1");
        } 
        else if (collision.CompareTag("Enemy2"))
        {
            pointsToBeAdded = 20;
            FindObjectOfType<InvaderManager>().speedUp();
            // Debug.Log("Hit Enemy 2");
        }
        else if (collision.CompareTag("Enemy3"))
        {
            pointsToBeAdded = 10;
            FindObjectOfType<InvaderManager>().speedUp();
            // Debug.Log("Hit Enemy 3");
        }
        else if (collision.CompareTag("Enemy4"))
        {
            pointsToBeAdded = Random.Range(1, 10)*10;
            FindObjectOfType<InvaderManager>().speedUp();
            // Debug.Log("Hit Enemy 4");
        }

        //If its a shield or wall, destroy enemy
        if (!collision.CompareTag("Wall"))
        {
            Destroy(collision.gameObject);
        }

        FindObjectOfType<UI>().addToScore(pointsToBeAdded);
        FindObjectOfType<Player>().resetBullet();
        Destroy(this.gameObject);
    }
}
