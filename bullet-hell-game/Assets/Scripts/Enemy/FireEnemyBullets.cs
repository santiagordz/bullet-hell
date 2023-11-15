using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FireEnemyBullets : MonoBehaviour
{
    public Transform playerTransform;
    public GameObject bulletPrefab;

    private void Start()
    {
        InvokeRepeating("Fire", 0f, 0.25f * Time.timeScale);
    }

    private void Fire()
    {
        if (playerTransform == null) return; // Ensure there's a player to target

        GameObject bul = Instantiate(bulletPrefab);
        bul.transform.position = transform.position; // Consider offsetting this if needed
        bul.SetActive(true);

        // Calculate direction towards the player
        Vector3 bulDir = (playerTransform.position - transform.position).normalized;
        bul.GetComponent<Bullet>().SetMoveDirection(bulDir);
        bul.GetComponent<Bullet>().SetColor(new Color(191f, 0f, 143f)); // Adjusted color values to be within 0-1 range
    }


}
