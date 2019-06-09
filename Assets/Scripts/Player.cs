using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private GameObject shotgun, enemyObj, pointer;
    public PlayerHealth playerHealth;
    public LevelManager levelManager;
    public GameObject fireEffect, gameLauncher, damageFlash;
    private Transform pointerTransform;
    public AudioManager audioManager;
    public FlashManager flashManager;

    public int kills = 0;
    

    private void OnEnable()
    {
        shotgun = GameObject.Find("ShotGun");
        pointer = GameObject.Find("GvrReticlePointer");
        pointerTransform = pointer.GetComponent<GvrReticlePointer>().PointerTransform;
    }

    // Update is called once per frame
    void Update()
    {
        
        enemyObj = null;
        RaycastHit hit;

        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
            if(Physics.Raycast(pointerTransform.position, pointerTransform.forward, out hit))
            {
                if(hit.transform.gameObject.tag == "enemy")
                {
                    enemyObj = hit.transform.gameObject;
                    enemyObj.GetComponent<Zombie>().Die();
                    enemyObj.GetComponent<Zombie>().StopMoving();
                    StartCoroutine(KillEnemy(enemyObj));
                }
            }
        }

        if(playerHealth.isDead)
        {
            StartCoroutine(PlayerDeath());
        }
    }

    public void Fire()
    {
       fireEffect.GetComponent<ParticleSystem>().Play();
       shotgun.GetComponent<AudioSource>().clip = audioManager.playerShoot;
       shotgun.GetComponent<AudioSource>().Play();
    }

    IEnumerator KillEnemy(GameObject enemy)
    {
        yield return new WaitForSeconds(1);
        Destroy(enemy);
        kills += 1;
    }

    IEnumerator PlayerDeath()
    {
        gameObject.GetComponent<AudioSource>().clip = audioManager.playerDieScream;
        gameObject.GetComponent<AudioSource>().Play();
        flashManager.Fade(true, 2.25f);
        playerHealth.isDead = false;
        levelManager.GameRestart();
        yield return new WaitForSeconds(4);
        flashManager.Fade(false, 1.25f);
        yield return new WaitForSeconds(0.5f);
    }
}
