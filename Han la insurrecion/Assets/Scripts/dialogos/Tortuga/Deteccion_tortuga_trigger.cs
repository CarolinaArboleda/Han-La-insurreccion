using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deteccion_tortuga_trigger : MonoBehaviour
{
    public GameObject trigger;
    void OnTriggerEnter2D(Collider2D other)
    {
        LiuBangCH player = other.gameObject.GetComponent<LiuBangCH>();


        if (player != null)
        {
            trigger.GetComponent<dialogo_tortuga_trigger>().TriggerDialogue();

        }
    }
}
