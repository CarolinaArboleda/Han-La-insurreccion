using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialogo_fenix_manager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
    public GameObject fenix;
    public GameObject liubang;

    public Animator animator;

    private Queue<string> frases;

    void Start()
    {
        frases = new Queue<string>();
        liubang.GetComponent<LiuBangCH>().Moving = false;
    }

    public void StartDialogue(dialogo_fenix dialogo_fenix)
    {
        animator.SetBool("isOpen", true);
        nameText.text = dialogo_fenix.name;

        frases.Clear();

        foreach (string frase in dialogo_fenix.frases)
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
        Destroy(FindObjectOfType<deteccion_fenix_trigger>());
        fenix.GetComponent<fenix>().endDialogue = true;
        liubang.GetComponent<LiuBangCH>().Moving = true;
    }

}
