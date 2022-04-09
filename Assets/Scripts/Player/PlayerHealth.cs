using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealthThreshold = 200;
    public int startingHealth = 100;
    public int maxHealth;
    public int currentHealth;
    public Slider healthSlider;
    public Image damageImage;
    public AudioClip deathClip;
    public float flashSpeed = 5f;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);


    Animator animation;
    AudioSource playerAudio;
    PlayerMovement playerMovement;
    PlayerShooting playerShooting;
    bool isDead;                                                
    bool damaged;          
                                     


    void Awake()
    {
        maxHealth = 100;
        animation = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        playerMovement = GetComponent<PlayerMovement>();
        playerShooting = GetComponentInChildren<PlayerShooting>();
        healthSlider = GameObject.Find("HeartSlider").GetComponent<Slider>();
        currentHealth = startingHealth;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
    }


    void Update()
    {
        if (damaged)
        {
            damageImage.color = flashColour;
        }
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }

        if (GameLogics.mode == 1) {
            ScoreManager.score +=  Time.deltaTime;
        }

        damaged = false;
    }


    public void TakeDamage(int amount)
    {
        damaged = true;

        currentHealth -= amount;

        healthSlider.value = currentHealth;

        playerAudio.Play();

        if (currentHealth <= 0 && !isDead)
        {
            Death();
        }
    }


    void Death()
    {
        isDead = true;

        playerShooting.DisableEffects();

        animation.SetTrigger("DED");

        playerAudio.clip = deathClip;
        playerAudio.Play();

        playerMovement.enabled = false;
        playerShooting.enabled = false;
    }

    public void healthUpdater() {
        currentHealth += 20;
        healthSlider.value = currentHealth;
    }

    public void maxHealthUpdater() {
        maxHealth += 20;
        healthSlider.maxValue = maxHealth;
    }
}
