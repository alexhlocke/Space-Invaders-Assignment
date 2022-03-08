using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void OnTriggerEnter2D (Collider2D collider) {
      if (collider.CompareTag("FailZone")) {
        FindObjectOfType<UI>().gameOver();
      }
    }
}
