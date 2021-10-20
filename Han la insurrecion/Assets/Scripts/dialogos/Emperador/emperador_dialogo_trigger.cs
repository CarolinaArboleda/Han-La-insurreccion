using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class emperador_dialogo_trigger : MonoBehaviour
{
    public emperador_dialogo dialogo;

    public void TriggerDialogue()
    {
        FindObjectOfType<emperador_dialogo_manager>().StartDialogue(dialogo);
    }
}
