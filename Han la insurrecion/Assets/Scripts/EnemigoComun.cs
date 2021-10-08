using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoComun : MonoBehaviour
{
    public float speed = 2;
    public bool vertical;
    public float changeTime = 3.0f;

    Rigidbody2D rigidbody2D;
    float timer;
    int direction = 1;
    bool broken = true;
    int shootsFix;

    // Start is called before the first frame update
    Animator animator;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        timer = changeTime;
        shootsFix = 2;
        //animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!broken)
        {
            return;
        }

        timer -= Time.deltaTime;

        if (timer < 0)
        {
            direction = -direction;
            timer = changeTime;
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

    void OnCollisionEnter2D(Collision2D other)
    {
       LiuBangCH player = other.gameObject.GetComponent<LiuBangCH>();

        if (player != null)
        {
            player.ChangeHealth(-1);
        }
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
}
