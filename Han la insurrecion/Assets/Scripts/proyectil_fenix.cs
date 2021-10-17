using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class proyectil_fenix : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    float destroyTime;

    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        destroyTime = 1.0f;
    }

    public void Launch(Vector2 direction, float force)
    {
        rigidbody2d.AddForce(direction * force);
    }


    void Update()
    {
        destroyTime -= Time.deltaTime;

        if (transform.position.magnitude > 1000.0f || destroyTime <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        LiuBangCH player = other.gameObject.GetComponent<LiuBangCH>();

        if (player != null)
        {
            player.ChangeHealth(-1);
        }
    }
}
