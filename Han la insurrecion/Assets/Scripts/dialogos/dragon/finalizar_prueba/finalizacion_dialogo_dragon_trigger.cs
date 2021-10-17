using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finalizacion_dialogo_dragon_trigger : MonoBehaviour
{
    public finalizacion_dialogo_dragon dialogo;

    public void TriggerDialogue()
    {
        FindObjectOfType<finalizacion_dialogo_dragon_manager>().StartDialogue(dialogo);
    }
}
