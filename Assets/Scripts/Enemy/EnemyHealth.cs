using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
    public float sinkSpeed = 2.5f;
    public int scoreValue = 10;
    public AudioClip deathClip;

    
    Animator animation;
    AudioSource enemyAudio;
    ParticleSystem hitParticles;
    CapsuleCollider capsuleCollider;
    bool isDead;
    bool isSinking;

    GameObject player;
    PlayerMovement pmovement;
    PlayerHealth phealth;
    PlayerShooting pshooting;


    void Awake ()
    {
        animation = GetComponent <Animator> ();
        enemyAudio = GetComponent <AudioSource> ();
        hitParticles = GetComponentInChildren <ParticleSystem> ();
        capsuleCollider = GetComponent <CapsuleCollider> ();

        currentHealth = startingHealth;

        // EDIT
        player = GameObject.FindGameObjectWithTag ("Player");
        pmovement = player.GetComponent <PlayerMovement> ();
        phealth = player.GetComponent <PlayerHealth> ();
        pshooting = player.GetComponentInChildren <PlayerShooting> ();
    }


    void Update ()
    {
        if (isSinking)
        {
            transform.Translate (-Vector3.up * sinkSpeed * Time.deltaTime);
        }
    }


    public void TakeDamage (int amount, Vector3 hitPoint)
    {
        if (isDead)
            return;

        enemyAudio.Play ();

        currentHealth -= amount;

        hitParticles.transform.position = hitPoint;
        hitParticles.Play();

        if (currentHealth <= 0)
        {
            Death ();
        }
    }


    void Death ()
    {
        if (pmovement.speed<pmovement.maxspeed) {
            pmovement.speedUpdater();
            if (pmovement.speed>=pmovement.maxspeed) {
                pmovement.speed = pmovement.maxspeed;
            }
            Debug.Log("Speed = " + pmovement.speed);
        }

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

        if (pshooting.power < pshooting.maxpower) {
            pshooting.powerUpdater();
            if (pshooting.power>=pshooting.maxpower) {
                pshooting.power = pshooting.maxpower;
            }
            Debug.Log("Power = " + pshooting.power);
        }

        isDead = true;

        capsuleCollider.isTrigger = true;

        animation.SetTrigger ("DEAD");

        enemyAudio.clip = deathClip;
        enemyAudio.Play ();
    }


    public void StartSinking ()
    {
        GetComponent<UnityEngine.AI.NavMeshAgent> ().enabled = false;
        GetComponent<Rigidbody> ().isKinematic = true;
        isSinking = true;
        ScoreManager.score += scoreValue;
        Destroy (gameObject, 2f);
    }
}
