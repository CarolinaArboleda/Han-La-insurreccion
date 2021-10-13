using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpVidaMaxima : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        LiuBangCH controller = other.GetComponent<LiuBangCH>();

        if (controller != null)
        {
            controller.additMaxHealth = 3;
            Destroy(gameObject);
            Debug.Log("Max Health INCREASED");
            controller.currentHealth = controller.maxHealth + controller.additMaxHealth;

        }
    }

}
