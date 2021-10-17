using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class finalizacion_dialogo_dragon_manager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;

    public Animator animator;

    private Queue<string> frases;

    void Start()
    {
        frases = new Queue<string>();
    }

    public void StartDialogue(finalizacion_dialogo_dragon dialogo_dragon)
    {
        animator.SetBool("isOpen", true);

        nameText.text = dialogo_dragon.name;

        frases.Clear();

        foreach (string frase in dialogo_dragon.frases)
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
        animator.SetBool("isOpen", false);
        Debug.Log("Finalizó la conversación");
    }

}
