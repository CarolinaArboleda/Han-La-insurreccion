using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtOfWar : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        LiuBangCH controller = other.GetComponent<LiuBangCH>();

        if (controller != null)
        {
            controller.attackBonus = controller.attackBonus + 10;
            Destroy(gameObject);
            
        }
    }
}
