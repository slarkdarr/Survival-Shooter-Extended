using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthOrb : MonoBehaviour
{
    GameObject player;
    PlayerHealth phealth;

    void Awake ()
    {
        player = GameObject.FindGameObjectWithTag ("Player");
        phealth = player.GetComponent <PlayerHealth> ();
        StartCoroutine(Dikacangin());
    }

    void OnTriggerEnter (Collider other)
    {
        if(other.gameObject == player && other.isTrigger == false)
        {
            Pickup();
            
        }
    }

    // void OnTriggerExit (Collider other)
    // {
    //     if(other.gameObject == player)
    //     {
    //         Pickup();
    //     }
    // }

    void Pickup() {
        if (phealth.maxHealth < phealth.maxHealthThreshold) {
            phealth.maxHealthUpdater();
            if (phealth.maxHealth >= phealth.maxHealthThreshold) {
                phealth.maxHealth = phealth.maxHealthThreshold;
            }
            Debug.Log("Max health = " + phealth.maxHealth);
        }

        if (phealth.currentHealth <= phealth.maxHealth) {
            phealth.healthUpdater();
            if (phealth.currentHealth > phealth.maxHealth) {
                phealth.currentHealth = phealth.maxHealth;
            }
            Debug.Log("Current health = " + phealth.currentHealth);
        }
        Destroy (gameObject);
    }

    IEnumerator Dikacangin() {
        yield return new WaitForSeconds(4f);
        Destroy(gameObject);
    }
}
