using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;


public class Zombie : MonoBehaviour, IPointerClickHandler
{
    public Transform goal;
    private Animator anim;
    private NavMeshAgent agent;
    public ParticleSystem bloodSplat;
    private GameObject player;
    private int frames = 0;
    public AudioSource zombieAudio;
    public AudioManager audioManager;

    void OnEnable()
    {
        player = GameObject.Find("Player");
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();

        StartMoving();
    }

    // Update is called once per frame
    void Update()
    {
        frames++;
        Vector3 relativePos = goal.position - transform.position;
        Quaternion.LookRotation(relativePos);
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("attack"))
        {
            if (frames % 10 == 0)
            {
                player.GetComponent<PlayerHealth>().TakeDamage(1);
            }

        } 

    }

    void StartMoving()
    {
        agent.destination = goal.position;
        zombieAudio.clip = audioManager.zombieWalking;
        zombieAudio.Play();
        zombieAudio.loop = true;
    }

    public void StopMoving()
    {
        agent.speed = 0;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Attack")
        {
            StopMoving();
            AttackPlayer();
        }
    }

    void AttackPlayer()
    {
        zombieAudio.clip = audioManager.zombieAttacking;
        zombieAudio.Play();
        zombieAudio.loop = true;
        anim.SetTrigger("attack"); 
    }

    public void Die()
    {
        zombieAudio.clip = audioManager.bloodSplash;
        zombieAudio.Play();
        bloodSplat.Play();
        anim.SetTrigger("shot");
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        //throw new System.NotImplementedException();
    }
}
