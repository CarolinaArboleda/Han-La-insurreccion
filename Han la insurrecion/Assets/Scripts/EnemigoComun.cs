using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoComun : MonoBehaviour
{
    public float speed = 2.5f;
    public bool vertical;
    public float changeTime = 3.0f;

    Rigidbody2D rigidbody2D;
    float timer;
    int direction = 1;
    bool broken = true;
    int shootsFix;

    bool isFrozen;
    float frozenTimer;
    public float timeFrozen = 2.0f;

    Transform target;
    float moveSpeed = 1.5f;
    private float rotationSpeed = 6;

    Transform myTransform;

    public int maxHealth = 100;
    int currentHealth;

    Animator animator;

    void Awake()
    {
        myTransform = transform;
    }

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        timer = changeTime;
        shootsFix = 2;
        target = GameObject.FindWithTag("Player").transform; //target the player
        //animator = GetComponent<Animator>();
        currentHealth = maxHealth;
    }

    void Update()
    {
        if (!broken)
        {
            return;
        }

        timer -= Time.deltaTime;

        float distancia;
        distancia = Vector2.Distance(target.transform.position, transform.position);

        //Si la distancia es menor a 5
        if (distancia < 5)
        {
            //Caminar
            myTransform.position += (target.position - myTransform.position) * moveSpeed * Time.deltaTime;
            //Lineas de debug que aparecen en la ventana Scene
            Debug.DrawLine(target.transform.position, transform.position, Color.red, Time.deltaTime, false);
        }
        else if (timer < 0)
        {
            direction = -direction;
            timer = changeTime;
        }

        if (isFrozen)
        {
            frozenTimer -= Time.deltaTime;
            if (frozenTimer <= 0)
            {
                Debug.Log("unu");
                ChangeSpeed();
                isFrozen = false;

            }
                
        }
    }

    void FixedUpdate()
    {
        Vector2 position = rigidbody2D.position;

        if (vertical)
        {
            position.y = position.y + Time.deltaTime * speed * direction; ;
            //animator.SetFloat("Move X", 0);
            //animator.SetFloat("Move Y", direction);
        }
        else
        {
            position.x = position.x + Time.deltaTime * speed * direction; ;
            //animator.SetFloat("Move X", direction);
            //animator.SetFloat("Move Y", 0);
        }

        rigidbody2D.MovePosition(position);
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

        // isFrozen = true;
        // frozenTimer  -= Time.deltaTime;
        speed = speed * 0;
        Debug.Log("Speed: " + speed);

        // speed = speed * 0;
        // moveSpeed = moveSpeed * 0;
        // rotationSpeed = rotationSpeed * 0;



        //if (frozenTimer <= 0)
        // {
        //   speed = 1.5f;
        //}


        //Debug.Log(isFrozen);
    }

    public void Fix()
    {
        shootsFix--;
        if (shootsFix <= 0)
        {
            broken = false;
            rigidbody2D.simulated = false;
            //animator.SetTrigger("Fixed");
        }
    }

    public void takeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemy died!");

        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;

        //Animator

        Destroy(gameObject);

    }

}

