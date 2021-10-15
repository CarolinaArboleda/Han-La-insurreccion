using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fenix : MonoBehaviour
{

    public bool isFrozen;
    float frozenTimer;
    public float timeFrozen = 50.0f;
    public float speed = 2.5f;

    // Start is called before the first frame update
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
        Debug.Log("Speed: " + speed);
    }

    // Update is called once per frame
    void Update()
    {
        if (isFrozen)
        {
            frozenTimer -= Time.deltaTime;
            if (frozenTimer <= 0)
            {
                Debug.Log("unu");
                speed = 2.5f;
                isFrozen = false;
                frozenTimer = timeFrozen;
            }

        }
    }
}
