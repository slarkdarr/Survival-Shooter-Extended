using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PlayerShooting : MonoBehaviour
{
    public int initialDamage = 20;             
    public float timeBetweenBullets = 0.15f;        
    public float range = 5f;                      
    public int power = 1;
    public int maxpower = 10;
    public float maxspeed = 0.075f;
    public float maxrange = 100f;
    public float slow = 1f;
    public Slider powerSlider;

    float timer;                                    
    Ray shootRay;                                   
    Ray shootRay2;                                   
    Ray shootRay3;                                   
    Ray shootRay4;                                   
    Ray shootRay5;                                   
    RaycastHit shootHit;                            
    int shootableMask;                             
    ParticleSystem gunParticles;                    
    LineRenderer gunLine;                           
    LineRenderer gunLine2;                           
    LineRenderer gunLine3;                           
    LineRenderer gunLine4;                           
    LineRenderer gunLine5;                           
    AudioSource gunAudio;                           
    Light gunLight;                                  
    int initPower = 1;
    float effectsDisplayTime = 0.2f;                
    List<LineRenderer> lines = new List<LineRenderer>();
    Material lineMaterial;

    int rand = 0;


    void Awake()
    {
        shootableMask = LayerMask.GetMask("Shootable");
        gunParticles = GetComponent<ParticleSystem>();
        gunLine = GetComponent<LineRenderer>();
        gunAudio = GetComponent<AudioSource>();
        gunLight = GetComponent<Light>();
        powerSlider = GameObject.Find("PowerSlider").GetComponent<Slider>();
        powerSlider.minValue = initPower;

        // Additional gunline

        if (rand != 0)
        {
            lineMaterial = Resources.Load("LineRenderMaterial", typeof(Material)) as Material;

            gunLine2 = new GameObject().AddComponent<LineRenderer>();
            gunLine2.gameObject.name = "GunLine2";
            gunLine2.gameObject.transform.SetParent(transform, false);
            // just to be sure reset position and rotation as well
            gunLine2.gameObject.transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);

            gunLine3 = new GameObject().AddComponent<LineRenderer>();
            gunLine3.gameObject.name = "GunLine3";
            gunLine3.gameObject.transform.SetParent(transform, false);
            // just to be sure reset position and rotation as well
            gunLine3.gameObject.transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);

            lines.Add(gunLine2);
            lines.Add(gunLine3);

            if (rand == 2)
            {
                gunLine4 = new GameObject().AddComponent<LineRenderer>();
                gunLine4.gameObject.name = "GunLine4";
                gunLine4.gameObject.transform.SetParent(transform, false);
                // just to be sure reset position and rotation as well
                gunLine4.gameObject.transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);

                gunLine5 = new GameObject().AddComponent<LineRenderer>();
                gunLine5.gameObject.name = "GunLine5";
                gunLine5.gameObject.transform.SetParent(transform, false);
                // just to be sure reset position and rotation as well
                gunLine5.gameObject.transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);

                lines.Add(gunLine4);
                lines.Add(gunLine5);
            }
        }

        foreach (var line in lines)
        {
            line.material = lineMaterial;
            line.SetWidth(0.05f, 0.05f);
        }
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (Input.GetButton("Fire1") && timer >= timeBetweenBullets)
        {
            Shoot();
        }

        if (timer >= timeBetweenBullets * effectsDisplayTime)
        {
            DisableEffects();
        }
    }

    public void DisableEffects()
    {
        gunLight.enabled = false;
        gunLine.enabled = false;
        
        if (rand != 0)
        {
            gunLine2.enabled = false;
            gunLine3.enabled = false;
            if (rand == 2)
            {
                gunLine4.enabled = false;
                gunLine5.enabled = false;
            }
        }
    }

    public void powerUpdater() {
        power += 1;
        powerSlider.value = power;
    }

    public void speedUpdater() {
        timeBetweenBullets *= 0.95f;
    }

    public void rangeUpdater() {
        range *= 1.2f;
    }

    void Shoot()
    {
        timer = 0f;

        gunAudio.Play();

        gunLight.enabled = true;

        gunParticles.Stop();
        gunParticles.Play();

        gunLine.enabled = true;
        gunLine.SetPosition(0, transform.position);

        shootRay.origin = transform.position;
        shootRay.direction = transform.forward; 

        if (rand == 0)
        {
            if (Physics.Raycast(shootRay, out shootHit, range, shootableMask))
            {
                EnemyHealth enemyHealth = shootHit.collider.GetComponent<EnemyHealth>();

                if (enemyHealth != null)
                {
                    int damagePerShot = initialDamage * power;
                    enemyHealth.TakeDamage(damagePerShot, shootHit.point);
                }

                gunLine.SetPosition(1, shootHit.point);
            }
            
            else
            {
                gunLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
            }
        }

        else
        {
            gunLine2.enabled = true;
            gunLine2.SetPosition(0, transform.position);

            gunLine3.enabled = true;
            gunLine3.SetPosition(0, transform.position);


            shootRay2.origin = transform.position;
            shootRay2.direction = Quaternion.Euler(0,22,0) * transform.forward;

            shootRay3.origin = transform.position;
            shootRay3.direction = Quaternion.Euler(0,-22,0) * transform.forward;

            if (rand == 1)
            {
                if (Physics.Raycast(shootRay, out shootHit, range, shootableMask))
                {
                    EnemyHealth enemyHealth = shootHit.collider.GetComponent<EnemyHealth>();

                    if (enemyHealth != null)
                    {
                        int damagePerShot = initialDamage * power;
                        enemyHealth.TakeDamage(damagePerShot, shootHit.point);
                    }

                    gunLine.SetPosition(1, shootHit.point);
                    gunLine2.SetPosition(1, shootRay2.origin + shootRay2.direction * range);
                    gunLine3.SetPosition(1, shootRay3.origin + shootRay3.direction * range);
                }
                else if (Physics.Raycast(shootRay2, out shootHit, range, shootableMask))
                {
                    EnemyHealth enemyHealth = shootHit.collider.GetComponent<EnemyHealth>();

                    if (enemyHealth != null)
                    {
                        int damagePerShot = initialDamage * power;
                        enemyHealth.TakeDamage(damagePerShot, shootHit.point);
                    }

                    gunLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
                    gunLine2.SetPosition(1, shootHit.point);
                    gunLine3.SetPosition(1, shootRay3.origin + shootRay3.direction * range);
                }
                else if (Physics.Raycast(shootRay3, out shootHit, range, shootableMask))
                {
                    EnemyHealth enemyHealth = shootHit.collider.GetComponent<EnemyHealth>();

                    if (enemyHealth != null)
                    {
                        int damagePerShot = initialDamage * power;
                        enemyHealth.TakeDamage(damagePerShot, shootHit.point);
                    }

                    gunLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
                    gunLine2.SetPosition(1, shootRay2.origin + shootRay2.direction * range);
                    gunLine3.SetPosition(1, shootHit.point);
                }
                else
                {
                    gunLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
                    gunLine2.SetPosition(1, shootRay2.origin + shootRay2.direction * range);
                    gunLine3.SetPosition(1, shootRay3.origin + shootRay3.direction * range);
                }
            }

            else
            {
                gunLine4.enabled = true;
                gunLine4.SetPosition(0, transform.position);

                gunLine5.enabled = true;
                gunLine5.SetPosition(0, transform.position);


                shootRay4.origin = transform.position;
                shootRay4.direction = (transform.forward + transform.right).normalized;

                shootRay5.origin = transform.position;
                shootRay5.direction = (transform.forward - transform.right).normalized;

                if (Physics.Raycast(shootRay, out shootHit, range, shootableMask))
                {
                    EnemyHealth enemyHealth = shootHit.collider.GetComponent<EnemyHealth>();

                    if (enemyHealth != null)
                    {
                        int damagePerShot = initialDamage * power;
                        enemyHealth.TakeDamage(damagePerShot, shootHit.point);
                    }

                    gunLine.SetPosition(1, shootHit.point);
                    gunLine2.SetPosition(1, shootRay2.origin + shootRay2.direction * range);
                    gunLine3.SetPosition(1, shootRay3.origin + shootRay3.direction * range);
                    gunLine4.SetPosition(1, shootRay4.origin + shootRay4.direction * range);
                    gunLine5.SetPosition(1, shootRay5.origin + shootRay5.direction * range);
                }
                else if (Physics.Raycast(shootRay2, out shootHit, range, shootableMask))
                {
                    EnemyHealth enemyHealth = shootHit.collider.GetComponent<EnemyHealth>();

                    if (enemyHealth != null)
                    {
                        int damagePerShot = initialDamage * power;
                        enemyHealth.TakeDamage(damagePerShot, shootHit.point);
                    }

                    gunLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
                    gunLine2.SetPosition(1, shootHit.point);
                    gunLine3.SetPosition(1, shootRay3.origin + shootRay3.direction * range);
                    gunLine4.SetPosition(1, shootRay4.origin + shootRay4.direction * range);
                    gunLine5.SetPosition(1, shootRay5.origin + shootRay5.direction * range);
                }
                else if (Physics.Raycast(shootRay3, out shootHit, range, shootableMask))
                {
                    EnemyHealth enemyHealth = shootHit.collider.GetComponent<EnemyHealth>();

                    if (enemyHealth != null)
                    {
                        int damagePerShot = initialDamage * power;
                        enemyHealth.TakeDamage(damagePerShot, shootHit.point);
                    }

                    gunLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
                    gunLine2.SetPosition(1, shootRay2.origin + shootRay2.direction * range);
                    gunLine3.SetPosition(1, shootHit.point);
                    gunLine4.SetPosition(1, shootRay4.origin + shootRay4.direction * range);
                    gunLine5.SetPosition(1, shootRay5.origin + shootRay5.direction * range);
                }
                else if (Physics.Raycast(shootRay4, out shootHit, range, shootableMask))
                {
                    EnemyHealth enemyHealth = shootHit.collider.GetComponent<EnemyHealth>();

                    if (enemyHealth != null)
                    {
                        int damagePerShot = initialDamage * power;
                        enemyHealth.TakeDamage(damagePerShot, shootHit.point);
                    }

                    gunLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
                    gunLine2.SetPosition(1, shootRay2.origin + shootRay2.direction * range);
                    gunLine3.SetPosition(1, shootRay3.origin + shootRay3.direction * range);
                    gunLine4.SetPosition(1, shootHit.point);
                    gunLine5.SetPosition(1, shootRay5.origin + shootRay5.direction * range);
                }
                else if (Physics.Raycast(shootRay5, out shootHit, range, shootableMask))
                {
                    EnemyHealth enemyHealth = shootHit.collider.GetComponent<EnemyHealth>();

                    if (enemyHealth != null)
                    {
                        int damagePerShot = initialDamage * power;
                        enemyHealth.TakeDamage(damagePerShot, shootHit.point);
                    }

                    gunLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
                    gunLine2.SetPosition(1, shootRay2.origin + shootRay2.direction * range);
                    gunLine3.SetPosition(1, shootRay3.origin + shootRay3.direction * range);
                    gunLine4.SetPosition(1, shootRay4.origin + shootRay4.direction * range);
                    gunLine5.SetPosition(1, shootHit.point);
                }
                else
                {
                    gunLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
                    gunLine2.SetPosition(1, shootRay2.origin + shootRay2.direction * range);
                    gunLine3.SetPosition(1, shootRay3.origin + shootRay3.direction * range);
                    gunLine4.SetPosition(1, shootRay4.origin + shootRay4.direction * range);
                    gunLine5.SetPosition(1, shootRay5.origin + shootRay5.direction * range);
                }
            }
        }
    }
}