using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Congelar : MonoBehaviour
{
    Rigidbody2D rigidbody2d;

    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    public void LaunchIce(Vector2 direction, float force)
    {
        rigidbody2d.AddForce(direction * force);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        EnemigoComun enemigo = other.gameObject.GetComponent<EnemigoComun>();

        if (enemigo != null)
        {
            enemigo.ChangeSpeed();
        }
    }



    void Update()
    {

        if (transform.position.magnitude > 1000.0f)
        {
            Destroy(gameObject);
        }
    }
}
