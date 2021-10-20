using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogo_tigre_trigger : MonoBehaviour
{
    public dialogo_tigre dialogo;

    public void TriggerDialogue()
    {
        FindObjectOfType<Dialogo_tigre_manager>().StartDialogue(dialogo);
    }
}
