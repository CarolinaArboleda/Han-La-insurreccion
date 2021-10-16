using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpDash : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        LiuBangCH controller = other.GetComponent<LiuBangCH>();

        if (controller != null)
        {
            controller.conseguidoDash = true;
            Destroy(gameObject);
        }
    }
}
