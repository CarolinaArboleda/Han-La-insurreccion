using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ataque_dragon : MonoBehaviour
{
    public GameObject counter;
    public int firstShotTime = 0;
    public float speed = 5;
    public int direction = 0;
    public bool horizontal;


    Rigidbody2D rigidbody2D;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        LiuBangCH player = other.gameObject.GetComponent<LiuBangCH>();

        if (player != null)
        {
            player.ChangeHealth(-1);
        }
    }

    void FixedUpdate()
    {
        if (firstShotTime >= counter.GetComponent<TimerCountdown>().secondsLeft)
        {
            if (horizontal)
            {
                Vector2 position = rigidbody2D.position;
                position.x = position.x + Time.deltaTime * speed * direction; ;
                rigidbody2D.MovePosition(position);

                if (direction == -1)
                {
                    rigidbody2D.transform.localScale = new Vector2(-1, 1);
                }
                if (direction == 1)
                {
                    rigidbody2D.transform.localScale = new Vector2(1, 1);
                }

            }
            else
            {
                Vector2 position = rigidbody2D.position;
                position.y = position.y + Time.deltaTime * speed * direction; ;
                rigidbody2D.MovePosition(position);

                if (direction == -1)
                {
                    rigidbody2D.transform.localScale = new Vector2(1, 1);
                }
                if (direction == 1)
                {
                    rigidbody2D.transform.localScale = new Vector2(1, -1);
                }

            }
        }


    }
}
