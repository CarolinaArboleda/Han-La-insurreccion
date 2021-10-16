using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogo_dragon_trigger : MonoBehaviour
{
    public dialogo_dragon dialogo;

    public void TriggerDialogue()
    {
        FindObjectOfType<dialogo_dragon_manager>().StartDialogue(dialogo);
    }
}
