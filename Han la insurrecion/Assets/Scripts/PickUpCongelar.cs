using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpCongelar : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        LiuBangCH controller = other.GetComponent<LiuBangCH>();
        
        if (controller != null)
        {
            controller.conseguidoCongelar = true;
            Destroy(gameObject);
        }
    }
}
