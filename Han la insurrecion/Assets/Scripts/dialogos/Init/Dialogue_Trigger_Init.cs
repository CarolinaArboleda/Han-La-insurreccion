using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue_Trigger_Init : MonoBehaviour
{
    public Dialogue_Init dialogue;

    public void TriggerDialogue ()
    {
        FindObjectOfType<Dialogue_Manager_Init>().StartDialogue(dialogue);
    }
}
