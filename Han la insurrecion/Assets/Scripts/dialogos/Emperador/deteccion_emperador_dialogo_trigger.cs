using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deteccion_emperador_dialogo_trigger : MonoBehaviour
{
    public GameObject trigger;
    void OnTriggerEnter2D(Collider2D other)
    {
        LiuBangCH player = other.gameObject.GetComponent<LiuBangCH>();


        if (player != null)
        {
            trigger.GetComponent<emperador_dialogo_trigger>().TriggerDialogue();

        }
    }
}
