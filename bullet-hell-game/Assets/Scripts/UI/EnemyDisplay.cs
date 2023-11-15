using TMPro;
using UnityEngine;

public class EnemyDisplay : MonoBehaviour
{
    public TextMeshProUGUI enemyTextMesh;
    private int enemyCount;

    public int GetActiveEnemyCount()
    {
        int count = 0;
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            count++;
        }
        GameObject[] bosses = GameObject.FindGameObjectsWithTag("Boss");
        foreach (GameObject boss in bosses)
        {
            count++;
        }
        return count;
    }

    void Update()
    {
        if (enemyTextMesh != null)
        {
            enemyCount = GetActiveEnemyCount();
            // Actualiza el TextMesh con la cantidad de balas
            // Aquí estoy asumiendo que tienes una manera de obtener la cantidad de balas
            // Por ejemplo, podría ser bulletPool.activeBulletCount o algo similar
            if (enemyCount >= 0)
            {
                enemyTextMesh.text = enemyCount.ToString();
            }
            else
            {
                enemyTextMesh.text = "0";
            }
        }
    }
}
