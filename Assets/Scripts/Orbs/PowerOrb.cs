using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerOrb : MonoBehaviour
{
    GameObject player;
    PlayerShooting pshooting;

    void Awake ()
    {
        player = GameObject.FindGameObjectWithTag ("Player");
        pshooting = player.GetComponentInChildren <PlayerShooting> ();
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
        if (pshooting.power < pshooting.maxpower) {
            pshooting.powerUpdater();
            if (pshooting.power>=pshooting.maxpower) {
                pshooting.power = pshooting.maxpower;
            }
            Debug.Log("Power = " + pshooting.power);
        }
        Destroy (gameObject);
    }

    IEnumerator Dikacangin() {
        yield return new WaitForSeconds(4f);
        Destroy(gameObject);
    }
}
