using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaFuego : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    float destroyTime;
    public int fireballDamage = 60;

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
        EnemigoComun enemigo = other.gameObject.GetComponent<EnemigoComun>();
        emperador emperador = other.gameObject.GetComponent<emperador>();

        if (enemigo != null)
        {
            enemigo.GetComponent<EnemigoComun>().takeDamage(fireballDamage);
            Debug.Log("Fireball hit");
        }

        if (emperador != null)
        {
            emperador.ChangeSpeed();
            emperador.isFrozen = true;
        }
    }

    
}
