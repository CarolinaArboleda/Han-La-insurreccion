using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lanternTrue : MonoBehaviour
{
    public GameObject pickupTortuga;
    public GameObject textTrigger;
    void OnTriggerEnter2D(Collider2D other)
    {
        LiuBangCH controller = other.GetComponent<LiuBangCH>();

        if (controller != null)
        {
            pickupTortuga.SetActive(true);
            textTrigger.GetComponent<dialogo_tortuga_trigger>().TriggerDialogue();

            Destroy(gameObject);
        }
    }
}
