using System.Collections;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    public static event Action onHit;
    public Transform targetObj;
    public float speed = 2f;
    public float health = 10f;
    NavMeshAgent agent;
    private Animator animator;
    AudioSource deathSound;
    bool isDead = false;
    public ScoreScript scoreScript;
    public HealthBar playerDamage;
    public ParticleSystem blood;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        deathSound = GetComponent<AudioSource>();
        agent.destination = targetObj.position;

        // Score stuff
        if (scoreScript == null)
        {
            scoreScript = FindObjectOfType<ScoreScript>();
        }
    }

    void Update()
    {
        if (!isDead)
        {
            agent.destination = targetObj.position;
        }
        else
        {
            agent.destination = agent.destination;
        }
    }

    public void TakeDamage(float amount)
    {
        health -= amount;

        if (health <= 0f && isDead == false)
        {
            isDead = true;
            blood.Play();
            agent.isStopped = true;
            scoreScript.AddScore(100);
            Debug.Log("Score added");
            SoundManager.PlaySound(SoundType.DEATH);
            animator.SetBool("Isdead", true);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player hit!");
            onHit?.Invoke();
            SoundManager.PlaySound(SoundType.DAMAGED);
            playerDamage.PlayerDamage(.25f);
        }
    }
}

