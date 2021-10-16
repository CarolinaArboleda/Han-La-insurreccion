using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fenix : MonoBehaviour
{

    public bool isFrozen;
    float frozenTimer;
    public float timeFrozen = 50.0f;
    public float speed = 2.5f;

    void Start()
    {
        frozenTimer = timeFrozen;
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
    }
}
