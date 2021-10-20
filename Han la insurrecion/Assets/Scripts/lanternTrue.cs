using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lanternTrue : MonoBehaviour
{
    public GameObject pickupTortuga;
    void OnTriggerEnter2D(Collider2D other)
    {
        LiuBangCH controller = other.GetComponent<LiuBangCH>();

        if (controller != null)
        {
            pickupTortuga.SetActive(true);

            Destroy(gameObject);
        }
    }
}
