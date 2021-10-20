using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogo_tortuga_trigger : MonoBehaviour
{
    public dialogo_tortuga dialogo;

    public void TriggerDialogue()
    {
        FindObjectOfType<dialogo_tortuga_manager>().StartDialogue(dialogo);
    }
}
