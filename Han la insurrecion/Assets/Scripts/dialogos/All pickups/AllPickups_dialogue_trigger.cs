using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllPickups_dialogue_trigger : MonoBehaviour
{
    public AllPickups_dialogue dialogo;

    public void TriggerDialogue()
    {
        FindObjectOfType<AllPickups_dialogue_manager>().StartDialogue(dialogo);
    }
}
