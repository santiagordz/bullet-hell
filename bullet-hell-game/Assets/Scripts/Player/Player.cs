using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float speed;
    private float minZ = -8.95f;
    private float maxZ = 9.2f;
    private float minX = -9.29f;
    private float maxX = 9.29f;
    public GameObject laserPrefab;

    void Update()
    {
        speed = 10f;
        speed = speed * Time.timeScale;

        // Handle player movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput);
        transform.position += movement * speed * Time.deltaTime;

        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, minX, maxX),
            transform.position.y,
            Mathf.Clamp(transform.position.z, minZ, maxZ)
        );

        RotatePlayerToMouse();

        // Handle player shooting
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    private void RotatePlayerToMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero); // Assuming the ground plane is at y = 0

        float distance;
        if (groundPlane.Raycast(ray, out distance))
        {
            Vector3 point = ray.GetPoint(distance);
            Vector3 lookDirection = point - transform.position;
            lookDirection.y = 0; // Ensure rotation is only along the y-axis

            float angle = Mathf.Atan2(lookDirection.x, lookDirection.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(-90f, 0f, angle));
        }
    }


    private void Shoot()
    {
        Instantiate(laserPrefab, transform.position, transform.rotation);
    }
}
