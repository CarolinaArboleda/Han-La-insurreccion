using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fenix : MonoBehaviour
{

    public bool isFrozen;
    float frozenTimer;
    public float timeFrozen = 50.0f;
    public float speed = 2.5f;
    public Transform centro;
    private float xo, yo, x, y, r, angulo, tiempo;
    public bool endDialogue = false;
    public bool dialogueOnce = false;
    public GameObject barrera;
    public GameObject textTrigger;

    bool cooldownProjectile;
    float cooldownProjectileTimer;
    public float timecooldownProjectile = 5f;

    public GameObject projectilePrefab;
    public GameObject pickupFenix;
    public GameObject liuBang;

    Transform target;
    Transform myTransform;

    public int maxHealth = 100;
    public int currentHealth;

    public bool death = false;

    Rigidbody2D rigidbody2d;

    void Awake()
    {
        myTransform = transform;
    }

    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player").transform; //target the player
        frozenTimer = timeFrozen;
        cooldownProjectileTimer = timecooldownProjectile;
        r = 12f;
        angulo = Mathf.PI / 2;
        xo = centro.transform.position.x;
        yo = centro.transform.position.y;
        tiempo = 0f;
        currentHealth = maxHealth;

    }

    public void ChangeSpeed()
    {
        speed = speed * 0;
        Debug.Log("congelado fenix");
    }

    void Update()
    {

        if (isFrozen)
        {
            frozenTimer -= Time.deltaTime;
            if (frozenTimer <= 0)
            {
                speed = 2.5f;
                isFrozen = false;
                frozenTimer = timeFrozen;
            }

        }

        if (cooldownProjectile)
        {
            cooldownProjectileTimer -= Time.deltaTime;
            if (cooldownProjectileTimer < 0)
                cooldownProjectile = false;
        }

        if (endDialogue)
        {
            barrera.SetActive(true);
            if (tiempo >= 0.05f)
            {
                if (!isFrozen && !death)
                {
                    x = xo + r * Mathf.Cos(angulo);
                    y = yo + r * Mathf.Sin(angulo);
                    angulo = (angulo - Mathf.PI / 32) % (2 * Mathf.PI);
                    transform.localPosition = new Vector2(x, y);
                    tiempo = 0f;
                    launch();

                }
            }
            else
            {
                tiempo += Time.deltaTime;
            }

        }

        if (death && endDialogue && !dialogueOnce)
        {
            liuBang.GetComponent<LiuBangCH>().fenix_superado = true;
            pickupFenix.SetActive(true);
            textTrigger.GetComponent<dialogo_fenix_trigger>().TriggerDialogue();
            endDialogue = false;
            dialogueOnce = true;
        }
    }


    void launch()
    {
        if (cooldownProjectile)
            return;

        var heading = target.position - myTransform.position;
        var distance = heading.magnitude;
        var direction = heading / distance;

        GameObject projectileObject = Instantiate(projectilePrefab, rigidbody2d.position + Vector2.up * 0.5f, Quaternion.identity);
        proyectil_fenix projectile = projectileObject.GetComponent<proyectil_fenix>();
        projectile.Launch(direction,400);

        cooldownProjectile = true;
        cooldownProjectileTimer = timecooldownProjectile;
    }


    public void takeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log(currentHealth + "/" + maxHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemy died!");
        death = true;

        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        Destroy(gameObject);

    }

}
