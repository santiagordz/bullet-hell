using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 moveDirection;
    private float moveSpeed;

    private void OnEnable()
    {
        Destroy(gameObject, 5f);
    }

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        moveSpeed = 5f;
        moveSpeed = moveSpeed * Time.timeScale;
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }

    public void SetMoveDirection(Vector3 direction)
    {
        moveDirection = direction;
    }

    void OnTriggerEnter(Collider other)
    {
        // Opcional: puedes verificar si el objeto con el que colisionó es específico
        if (other.gameObject.tag == "Wall" || other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "Player")
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            playerHealth?.TakeDamage(5f);
        }
    }

    public void SetColor(Color color)
    {
        Renderer bulletRenderer = GetComponent<Renderer>();
        if (bulletRenderer != null)
        {
            bulletRenderer.material.SetColor("_EmissionColor", color);
        }
    }

    private void OnDisable()
    {
        CancelInvoke();
    }
}
