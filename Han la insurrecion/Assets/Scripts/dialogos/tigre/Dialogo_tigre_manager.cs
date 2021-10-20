using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogo_tigre_manager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
    public GameObject tigre;

    public Animator animator;

    private Queue<string> frases;

    void Start()
    {
        frases = new Queue<string>();
    }

    public void StartDialogue(dialogo_tigre dialogo_tigre)
    {
        animator.SetBool("isOpen", true);

        nameText.text = dialogo_tigre.name;

        frases.Clear();

        foreach (string frase in dialogo_tigre.frases)
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
        Destroy(FindObjectOfType<Deteccion_tigre_trigger>());
    }
}
