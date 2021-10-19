using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lanternFalse : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        LiuBangCH controller = other.GetComponent<LiuBangCH>();

        if (controller != null)
        {       
                controller.ChangeHealth(-4);
                Destroy(gameObject);
        }
    }
}
