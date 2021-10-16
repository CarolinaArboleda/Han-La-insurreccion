using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Congelar : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    float destroyTime;

    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        destroyTime = 1.0f;
    }

    public void LaunchIce(Vector2 direction, float force)
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
        EnemigoComun enemigo = other.gameObject.GetComponent<EnemigoComun>();

        if (enemigo != null)
        {
            enemigo.ChangeSpeed();
            enemigo.isFrozen = true;
        }
    }
}
