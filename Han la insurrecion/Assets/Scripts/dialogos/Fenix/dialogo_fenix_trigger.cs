using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogo_fenix_trigger : MonoBehaviour
{
    public dialogo_fenix dialogo;

    public void TriggerDialogue()
    {
        FindObjectOfType<dialogo_fenix_manager>().StartDialogue(dialogo);
    }
}
