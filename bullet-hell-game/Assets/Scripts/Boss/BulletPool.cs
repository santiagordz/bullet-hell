using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public static BulletPool bulletPoolInstance;

    [SerializeField]
    private GameObject pooledBullet;
    private List<GameObject> bullets;

    private void Awake()
    {
        bulletPoolInstance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        bullets = new List<GameObject>();
    }

    public GameObject GetBullet()
    {
        foreach (var bullet in bullets)
        {
            if (!bullet.activeInHierarchy)
            {
                return bullet;
            }
        }

        // Si todas las balas están en uso, crea una nueva (opcional)
        GameObject newBullet = Instantiate(pooledBullet);
        newBullet.SetActive(false);
        bullets.Add(newBullet);
        return newBullet;
    }
}
