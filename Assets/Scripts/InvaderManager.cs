using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvaderManager : MonoBehaviour
{
    public GameObject invader1;
    public GameObject invader2;
    public GameObject invader3;
    public GameObject invader4;
    public GameObject enemyBullet;
    public Transform spaceShipSpawn;
    public float movementSpeed;
    
    private float originalMoveSpeed;
    private int direction = 1; //1 for right -1 for left
    private int rows = 12;
    private int columns = 5;

    void Start()
    {
        instantiateInvaders();
        originalMoveSpeed = movementSpeed;
    }

    void Update()
    {
        bool allInvadersDead = true;

        if (Random.Range(0,30000) == 1) {
            GameObject ship = Instantiate(invader4, spaceShipSpawn.position, Quaternion.identity);
            Destroy(ship, 5f);
        }

        //Move
        this.transform.position += new Vector3(movementSpeed * Time.deltaTime * direction, 0.0f, 0.0f);

        //Check if in bounds
        //I found a helpful tutorial online that explained .activeInHeirarchy for this part
        foreach (Transform invader in this.transform) {
            if (!invader.gameObject.activeInHierarchy) {
                continue;
            }
            allInvadersDead = false;

            if (Random.Range(0,30000) == 1) {
                GameObject shot = Instantiate(enemyBullet, invader.position, Quaternion.identity);
            }

            if ((direction == 1 && invader.position.x >= 8.5f) 
            || (direction == -1 && invader.position.x <= -8.5f)) {
                direction *= -1;
                Vector3 newPos = this.transform.position;
                newPos.y -= 0.6f;
                this.transform.position = newPos;
                break;
            }
        }

        //Check if allInvadersDead / respawn new ones
        if (allInvadersDead) {
            FindObjectOfType<UI>().addLife();
            instantiateInvaders();
            movementSpeed += 0.1f;
        }
    }

    private void instantiateInvaders() {
        Vector3 spawnPos = new Vector3(-6.0f, 3.5f, 0.0f);
        GameObject toBeInstantiated;

        for (int i = 0; i < columns; i++) {
            for (int j = 0; j < rows; j++) {
                if (i == 0) {
                    toBeInstantiated = invader1;
                    //Instantiate(invader1, this.transform);
                }
                else if (i == 1 || i == 2) {
                    toBeInstantiated = invader2;
                    //Instantiate(invader2, this.transform);
                }
                else {
                    toBeInstantiated = invader3;
                    //Instantiate(invader3, this.transform);
                }

                GameObject invader = Instantiate(toBeInstantiated, this.transform);
                invader.transform.position = spawnPos;
        
                spawnPos.x += 1f;
            }
            spawnPos.y -= 0.6f;
            spawnPos.x = -6f;
        }
    }

    public void speedUp() {
        movementSpeed += 0.01f;
    }

    public void resetGame() {
        movementSpeed = originalMoveSpeed;

        foreach (Transform invader in this.transform) {
            if (!invader.gameObject.activeInHierarchy) {
                continue;
            }
            Destroy(invader.gameObject);
        }

        instantiateInvaders();
    }
}
