using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedOrb : MonoBehaviour
{
    GameObject player;
    PlayerMovement pmovement;

    void Awake ()
    {
        player = GameObject.FindGameObjectWithTag ("Player");
        pmovement = player.GetComponent <PlayerMovement> ();
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
        if (pmovement.speed<pmovement.maxspeed) {
            pmovement.speedUpdater();
            if (pmovement.speed>=pmovement.maxspeed) {
                pmovement.speed = pmovement.maxspeed;
            }
            Debug.Log("Speed = " + pmovement.speed);
        }
        Destroy (gameObject);
    }

    IEnumerator Dikacangin() {
        yield return new WaitForSeconds(4f);
        Destroy(gameObject);
    }
}
