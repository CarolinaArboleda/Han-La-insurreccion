using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AllPickups_dialogue_manager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;

    public Animator animator;

    private Queue<string> frases;

    void Start()
    {
        frases = new Queue<string>();
    }

    public void StartDialogue(AllPickups_dialogue dialogo_pickups)
    {
        animator.SetBool("IsOpen", true);

        nameText.text = dialogo_pickups.name;

        frases.Clear();

        foreach (string frase in dialogo_pickups.frases)
        {
            frases.Enqueue(frase);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (frases.Count == 0)
        {
            EndDialogue();
            return;
        }

        string frase = frases.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(frase));
    }

    IEnumerator TypeSentence(string frase)
    {
        dialogueText.text = " ";
        foreach (char letra in frase.ToCharArray())
        {
            dialogueText.text += letra;
            yield return null;
        }
    }

    public void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
        Debug.Log("Finalizó la conversación");
    }
}
