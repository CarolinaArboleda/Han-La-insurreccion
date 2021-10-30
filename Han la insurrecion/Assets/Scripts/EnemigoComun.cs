using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoComun : MonoBehaviour
{
    public float speed = 2.5f;
    public bool vertical;
    public float changeTime = 3.0f;
    private Animator anim;

    Rigidbody2D rigidbody2D;
    float timer;
    int direction = 1;
    bool broken = true;
    int shootsFix;

    public bool isFrozen;
    float frozenTimer;
    public float timeFrozen = 5.0f;

    Transform target;
    float moveSpeed = 1.5f;

    Transform myTransform;

    public int maxHealth = 100;
    public int currentHealth;

    Animator animator;
    Vector2 lookDirection = new Vector2(1, 0);

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
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
        frozenTimer = timeFrozen;
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
                speed = 2.5f;
                moveSpeed = 1.5f;
                isFrozen = false;
                frozenTimer = timeFrozen;
                animator.SetInteger("Estado", 0);
            }
                
        }
    
    }

    void FixedUpdate()
    {
        Vector2 position = rigidbody2D.position;

        if (vertical)
        {
            position.y = position.y + Time.deltaTime * speed * direction; ;
            //animator.SetFloat("Look X", 0);
            //animator.SetFloat("Look Y", direction);
        }
        else
        {
            position.x = position.x + Time.deltaTime * speed * direction; ;
            animator.SetFloat("Look X", direction);
            animator.SetFloat("Look Y", 0);
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
        speed = speed * 0;
        moveSpeed = moveSpeed * 0;
        Debug.Log("Speed: " + speed);
        animator.SetInteger("Estado", 1);
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
        Debug.Log(currentHealth + "/" + maxHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Debug.Log("Enemy died!");

        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;

        //Animator

        Destroy(gameObject);

    }

}

