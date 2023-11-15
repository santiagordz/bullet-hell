using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public float speed = 100f;
    private Rigidbody rb;
    private AudioSource audioSource;
    public AudioClip collisionClip; // Assign this in the inspector

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Destroy(gameObject, 5f);

        audioSource = GetComponent<AudioSource>();
        audioSource.pitch = Time.timeScale;
        audioSource.Play();

        // Add and configure the AudioSource for the collision sound
    }

    private void Update()
    {
        audioSource.pitch = Time.timeScale;
    }

    private void FixedUpdate()
    {
        rb.velocity = -transform.up * speed * Time.deltaTime * Time.timeScale;
    }

    void OnTriggerEnter(Collider other)
    {
        // Opcional: puedes verificar si el objeto con el que colisionó es específico
        if (other.gameObject.tag == "Wall" || other.gameObject.tag == "Boss" || other.gameObject.tag == "Enemy" || other.gameObject.tag == "EnemyLaser")
        {
            audioSource.Stop();
            audioSource.clip = collisionClip;
            audioSource.pitch = Time.timeScale;
            audioSource.Play();

            GetComponent<Renderer>().enabled = false;
            if (rb != null)
            {
                rb.velocity = Vector3.zero;
            }

            Destroy(gameObject, 0.5f);
        }

        if (other.gameObject.tag == "Boss")
        {
            BossHealth bossHealth = other.GetComponent<BossHealth>();
            bossHealth?.TakeDamage(10f);
        }
        if (other.gameObject.tag == "Enemy")
        {
            EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
            enemyHealth?.TakeDamage(10f);
        }
    }
}