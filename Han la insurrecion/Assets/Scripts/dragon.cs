using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragon : MonoBehaviour
{

    public bool isFrozen;
    float frozenTimer;
    public float timeFrozen = 50.0f;
    public float speed = 2.5f;

    void Start()
    {
        frozenTimer = timeFrozen;
    }

    public void ChangeSpeed()
    {
        speed = speed * 0;
        Debug.Log("congelado dragón");
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
