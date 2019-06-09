using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public GameObject town, shotgun, zombieSpawner, gameUI, zombieAttackRange, spawnPoints, gameManager, gameLauncher;
    public TextMeshProUGUI startBtntext;
    public PlayerHealth playerHealth;
    public Player player;

    void Start()
    {
        town.SetActive(false);
        shotgun.SetActive(false);
        zombieSpawner.SetActive(false);
        gameUI.SetActive(false);
        zombieAttackRange.SetActive(false);
        gameManager.SetActive(false);
        spawnPoints.SetActive(false);
        DestroyAllEnemiesInScene("enemy");
        gameLauncher.SetActive(true);

    }

    public void GameStart()
    {
        town.SetActive(true);
        shotgun.SetActive(true);
        zombieSpawner.SetActive(true);
        gameUI.SetActive(true);
        zombieAttackRange.SetActive(true);
        gameManager.SetActive(true);
        gameLauncher.SetActive(false);
        spawnPoints.SetActive(true);
    }


    public void DestroyAllEnemiesInScene(string tag)
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag(tag);
        foreach(GameObject target in gameObjects)
        {
            Destroy(target);
        }
    }

    public void GameRestart()
    {
        StartCoroutine(NewGame());
    }

    IEnumerator NewGame()
    {
        town.SetActive(false);
        shotgun.SetActive(false);
        zombieSpawner.SetActive(false);
        gameUI.SetActive(false);
        zombieAttackRange.SetActive(false);
        gameManager.SetActive(false);
        spawnPoints.SetActive(false);
        DestroyAllEnemiesInScene("enemy");
        yield return new WaitForSeconds(2);
        gameLauncher.SetActive(true);
        startBtntext.text = "RESTART";
        playerHealth.currentHealth = 100;
        player.kills = 0;
    }
}
