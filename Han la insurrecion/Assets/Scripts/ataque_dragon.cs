using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ataque_dragon : MonoBehaviour
{
    public GameObject counter;
    public int firstShotTime=0;
    public int secondShotTime=0;
    public float speed = 5;
    public int direction = 0;


    Rigidbody2D rigidbody2D;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (firstShotTime == counter.GetComponent<TimerCountdown>().secondsLeft)
        {
            Vector2 position = rigidbody2D.position;
            position.y = position.y + Time.deltaTime * speed * direction; ;
            rigidbody2D.MovePosition(position);
        }
    }

}
