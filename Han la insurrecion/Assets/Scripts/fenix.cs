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
    public GameObject barrera;

    bool cooldownProjectile;
    float cooldownProjectileTimer;
    public float timecooldownProjectile = 0.1f;

    public GameObject projectilePrefab;
    Transform target;
    Transform myTransform;

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
        r = 12f;
        angulo = Mathf.PI/2;
        xo = centro.transform.position.x;
        yo = centro.transform.position.y;
        tiempo = 0f;
        
    }

    void OnCollisionStay2D(Collision2D other)
    {
        LiuBangCH player = other.gameObject.GetComponent<LiuBangCH>();

        if (player != null)
        {
            player.ChangeHealth(-1);
        }
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
            if (tiempo >= 0.045f)
            {
                if (!isFrozen)
                {
                    x = xo + r * Mathf.Cos(angulo);
                    y = yo + r * Mathf.Sin(angulo);
                    angulo = (angulo - Mathf.PI / 32) % (2 * Mathf.PI);
                    transform.localPosition = new Vector2(x, y);
                    launch();
                    tiempo = 0f;
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
        projectile.Launch(direction,800);

        cooldownProjectile = true;
        cooldownProjectileTimer = timecooldownProjectile;
    }
}
