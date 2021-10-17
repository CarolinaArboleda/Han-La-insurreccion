using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deteccion_fenix_trigger : MonoBehaviour
{
    public GameObject trigger;
    void OnTriggerEnter2D(Collider2D other)
    {
        LiuBangCH player = other.gameObject.GetComponent<LiuBangCH>();


        if (player != null)
        {
            trigger.GetComponent<dialogo_fenix_trigger>().TriggerDialogue();

        }
    }
}
