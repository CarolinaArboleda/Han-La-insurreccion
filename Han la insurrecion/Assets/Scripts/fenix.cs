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
    public bool dialogueOnce = true;
    public GameObject barrera;
    public GameObject textTrigger;

    bool cooldownProjectile;
    float cooldownProjectileTimer;
    public float timecooldownProjectile = 4f;

    public GameObject projectilePrefab;
    public GameObject pickupFenix;
    public GameObject liuBang;

    Transform target;
    Transform myTransform;

    public int maxHealth = 200;
    public int currentHealth;

    public bool death = false;
    public bool inicio_desafío = false;

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

        if (endDialogue)// no sé cómo entra acá porque endDialogue nunca es verdadero, pero entra somehow
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
                    inicio_desafío = true;
                    launch();

                }
            }
            else
            {
                tiempo += Time.deltaTime;
            }

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
        if (inicio_desafío)
        {
            currentHealth -= damage;
            Debug.Log(currentHealth + "/" + maxHealth);

            if (currentHealth <= 0)
            {
                death = true;
                Die();
            }
        }
    }

    void Die()
    {
        Debug.Log("Enemy died!");
        liuBang.GetComponent<LiuBangCH>().fenix_superado = true;
        pickupFenix.SetActive(true);
        textTrigger.GetComponent<dialogo_fenix_trigger>().TriggerDialogue();
        barrera.SetActive(false);
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        gameObject.SetActive(false);

    }

}
