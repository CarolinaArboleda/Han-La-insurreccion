using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class emperador_dialogo_manager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
    public GameObject emperador;

    public Animator animator;

    private Queue<string> frases;

    void Start()
    {
        frases = new Queue<string>();
    }

    public void StartDialogue(emperador_dialogo emperador_dialogo)
    {
        animator.SetBool("isOpen", true);

        nameText.text = emperador_dialogo.name;

        frases.Clear();

        foreach (string frase in emperador_dialogo.frases)
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
        Destroy(FindObjectOfType<deteccion_emperador_dialogo_trigger>());
    }
}
