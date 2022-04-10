using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Santeterss : MonoBehaviour
{
    public float timeBetweenAttacks = 1f;
    public int attackDamage = 30;


    Animator animation;
    GameObject player;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    bool playerInRange;
    float timer;


    void Awake ()
    {
        player = GameObject.FindGameObjectWithTag ("Player");
        playerHealth = player.GetComponent <PlayerHealth> ();
        enemyHealth = GetComponent<EnemyHealth>();
        animation = GetComponent <Animator> ();
    }

    void OnTriggerEnter (Collider other)
    {
        if(other.gameObject == player && other.isTrigger == false)
        {
            playerInRange = true;
        }
    }

    void OnTriggerExit (Collider other)
    {
        if(other.gameObject == player)
        {
            playerInRange = false;
        }
    }


    void Update ()
    {
        timer += Time.deltaTime;

        if(timer >= timeBetweenAttacks && playerInRange && enemyHealth.currentHealth > 0)
        {
            Attack ();
        }

        if (playerHealth.currentHealth <= 0)
        {
            animation.SetTrigger ("PlayerDEAD");
        }
    }


    void Attack ()
    {
        timer = 0f;

        if (playerHealth.currentHealth > 0)
        {
            playerHealth.TakeDamage (attackDamage);
        }
    }
}
