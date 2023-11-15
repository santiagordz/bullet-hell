using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FireBullets : MonoBehaviour
{
    public GameObject bulletPrefab;
    public enum FireMode
    {
        FireSpiralWave,
        FireDoubleSpiral,
        Fire360Burst
    }

    private FireMode currentFireMode = FireMode.FireSpiralWave;
    private Dictionary<FireMode, float> fireRates = new Dictionary<FireMode, float>()
    {
        { FireMode.FireSpiralWave, 0.05f },
        { FireMode.FireDoubleSpiral, 0.25f },
        { FireMode.Fire360Burst, 0.75f }
    };

    private Dictionary<FireMode, Color> fireModeColors = new Dictionary<FireMode, Color>()
    {
        { FireMode.FireSpiralWave, new Color(191f, 0f, 143f) },
        { FireMode.FireDoubleSpiral, new Color(0f, 191f, 143f) },
        { FireMode.Fire360Burst, new Color(29f, 255f, 0f) }
    };

    private void UpdateFireRate()
    {
        CancelInvoke("Fire");
        float adjustedFireRate = fireRates[currentFireMode] * Time.timeScale;
        InvokeRepeating("Fire", 0f, adjustedFireRate);
    }


    // Start is called before the first frame update
    void Start()
    {
        UpdateFireRate();
        InvokeRepeating("ChangeFireMode", 10f, 10f);
    }

    private void ChangeFireMode()
    {
        currentFireMode = (FireMode)(((int)currentFireMode + 1) % 3);
        UpdateFireRate();
    }

    private void Fire()
    {
        Color currentColor = fireModeColors[currentFireMode];
        switch (currentFireMode)
        {
            case FireMode.FireSpiralWave:
                FireSpiralWave(currentColor);
                break;
            case FireMode.FireDoubleSpiral:
                FireDoubleSpiral(currentColor);
                break;
            case FireMode.Fire360Burst:
                Fire360Burst(currentColor);
                break;
        }
    }

    private float spiralAngle = 0f;
    private float spiralRadius = 1f;
    private float maxSpiralRadius = 0.5f; // Maximum radius of the spiral
    private float spiralRadiusStep = 0.1f; // Increase in radius per bullet
    private float spiralAngleStep = 10f; // Angle step per bullet

    private void FireSpiralWave(Color color)
    {
        Vector3 firingPointOffset = new Vector3(0f, 0f, 0); // Example offset, adjust as needed

        float bulDirX = Mathf.Cos(spiralAngle * Mathf.Deg2Rad);
        float bulDirZ = Mathf.Sin(spiralAngle * Mathf.Deg2Rad);
        Vector3 bulDir = new Vector3(bulDirX, 0f, bulDirZ);

        // GameObject bul = BulletPool.bulletPoolInstance.GetBullet();
        GameObject bul = Instantiate(bulletPrefab);
        bul.transform.position = transform.position + transform.rotation * firingPointOffset + bulDir * spiralRadius;
        bul.transform.rotation = transform.rotation;
        bul.SetActive(true);
        bul.GetComponent<Bullet>().SetMoveDirection(bulDir);
        bul.GetComponent<Bullet>().SetColor(color);

        spiralAngle += spiralAngleStep;
        spiralRadius += spiralRadiusStep;

        if (spiralRadius > maxSpiralRadius)
        {
            spiralRadius = 0f;
        }
    }

    private float angle = 0f; // Declare angle as a class-level variable

    private void FireDoubleSpiral(Color color)
    {
        for (int i = 0; i <= 4; i++)
        {
            float bulDirX = Mathf.Sin(((angle + 90f * i) * Mathf.PI) / 180f);
            float bulDirZ = Mathf.Cos(((angle + 90f * i) * Mathf.PI) / 180f);

            Vector3 bulDir = new Vector3(bulDirX, 0f, bulDirZ);
            bulDir = transform.rotation * bulDir;

            GameObject bul = Instantiate(bulletPrefab);
            bul.transform.position = transform.position;
            bul.transform.rotation = transform.rotation;
            bul.SetActive(true);
            bul.GetComponent<Bullet>().SetMoveDirection(bulDir);
            bul.GetComponent<Bullet>().SetColor(color);

        }

        angle += 10f; // Increment the angle

        if (angle >= 360f)
        {
            angle = 0f;
        }
    }

    private void Fire360Burst(Color color)
    {
        int bulletCount = 36; // Number of bullets in the burst, adjust for density
        float angleStep = 360f / bulletCount;

        for (int i = 0; i < bulletCount; i++)
        {
            float angle = i * angleStep;
            float bulDirX = Mathf.Sin((angle * Mathf.PI) / 180f);
            float bulDirZ = Mathf.Cos((angle * Mathf.PI) / 180f);

            Vector3 bulDir = new Vector3(bulDirX, 0f, bulDirZ);
            bulDir = transform.rotation * bulDir;

            GameObject bul = Instantiate(bulletPrefab);
            bul.transform.position = transform.position;
            bul.transform.rotation = transform.rotation;
            bul.SetActive(true);
            bul.GetComponent<Bullet>().SetMoveDirection(bulDir);
            bul.GetComponent<Bullet>().SetColor(color);

        }
    }
}
