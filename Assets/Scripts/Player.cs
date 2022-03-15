using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject bullet;
    public Transform shottingOffset;
    public Animator animator;
    public float movementSpeed = 6f;
    
    private bool bulletFired = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && bulletFired == false)
        {
            animator.SetTrigger("shoot");
            FindObjectOfType<AudioManager>().playSound("playerShoot");
            GameObject shot = Instantiate(bullet, shottingOffset.position, Quaternion.identity);
            bulletFired = true;
            //Destroy(shot, 3f);
        }
        move();
    }

    private void move()
    {
        float dir = Input.GetAxisRaw("Horizontal");
        this.transform.position += new Vector3(movementSpeed * Time.deltaTime * dir, 0.0f, 0.0f);
    }

    public void resetBullet()
    {
        bulletFired = false;
    }
}
