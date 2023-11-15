using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class LevelManager : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject player;
    public GameObject boss;
    public TextMeshProUGUI levelText;
    private Boolean BossLevel = false;
    private bool bossCreated = false;


    private int countEnemies()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        return enemies.Length;
    }

    private int countBoss()
    {
        GameObject[] bosses = GameObject.FindGameObjectsWithTag("Boss");
        return bosses.Length;
    }

    private bool AlivePlayer()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        return players.Length > 0;
    }

    private void Start()
    {
        levelText.text = "Level 1";
        StartCoroutine(WaitAndChangeText(""));
    }

    void Update()
    {
        if (!BossLevel && countEnemies() == 0)
        {
            Debug.Log("Pass to Boss Level");
            StartCoroutine(WaitAndPassToBossLevel());
        }
        if (BossLevel && countBoss() == 0)
        {
            WinLevel();
        }
        if (!AlivePlayer())
        {
            Lose();
        }
    }

    private IEnumerator WaitAndPassToBossLevel()
    {
        levelText.text = "Great Job!, Now you have to fight the Boss";
        yield return new WaitForSeconds(2f);
        PassToBossLevel();
    }

    private IEnumerator WaitAndChangeText(string newText)
    {
        yield return new WaitForSeconds(2f); // Wait for 2 seconds
        levelText.text = newText; // Change the text after the wait
    }

    public void PassToBossLevel()
    {
        BossLevel = true; // Don't forget to set BossLevel to true
        levelText.text = "Boss Level";
        StartCoroutine(WaitAndChangeText("")); // Wait and change the text
        if (!bossCreated) // Comprueba si el jefe ya ha sido creado
        {
            CreateBoss();
            bossCreated = true; // Establece bossCreated en true después de crear el jefe
        }
    }

    private void CreateBoss()
    {
        Instantiate(boss);
    }
    public void WinLevel()
    {
        levelText.text = "You Win!";
    }

    public void Lose()
    {
        levelText.text = "You Lose!";
    }
}
