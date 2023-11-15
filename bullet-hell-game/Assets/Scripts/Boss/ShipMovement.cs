using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    private float moveSpeedX;
    private float moveSpeedZ;
    private bool moveRight;
    private bool moveDown;
    private Transform playerTransform; // Reference to the player's transform

    // Start is called before the first frame update
    void Start()
    {
        moveSpeedX = 1f;
        moveSpeedZ = 0.5f;
        moveRight = true;
        moveDown = true;

        // Find the player object by tag (make sure your player has a tag assigned in the Inspector)
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        moveSpeedX = 4f;
        moveSpeedZ = 2f;
        moveSpeedX = moveSpeedX * Time.timeScale;
        moveSpeedZ = moveSpeedZ * Time.timeScale;
        // Move the ship horizontally
        if (transform.position.x > 7f)
        {
            moveRight = false;
        }
        else if (transform.position.x < -7f)
        {
            moveRight = true;
        }

        if (moveRight)
        {
            transform.position += new Vector3(moveSpeedX * Time.deltaTime / Time.timeScale, 0, 0);
        }
        else
        {
            transform.position -= new Vector3(moveSpeedX * Time.deltaTime / Time.timeScale, 0, 0);
        }

        // Move the ship vertically
        if (transform.position.z < -6f)
        {
            moveDown = false;
        }
        else if (transform.position.z >= 5f)
        {
            moveDown = true;
        }

        if (moveDown)
        {
            transform.position -= new Vector3(0, 0, moveSpeedZ * Time.deltaTime / Time.timeScale);
        }
        else
        {
            transform.position += new Vector3(0, 0, moveSpeedZ * Time.deltaTime / Time.timeScale);
        }

        // Make the boss look at the player
        // LookAtPlayer();
    }

    private void LookAtPlayer()
    {
        if (playerTransform == null) return;

        Vector3 directionToPlayer = playerTransform.position - transform.position;
        directionToPlayer.z = 0; // Keep the rotation in the 2D plane
        Quaternion lookRotation = Quaternion.LookRotation(Vector3.forward, directionToPlayer);
        transform.rotation = lookRotation;
    }
}
