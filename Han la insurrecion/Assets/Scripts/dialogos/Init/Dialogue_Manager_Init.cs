using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue_Manager_Init : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;

    public Animator animator;
    private Queue<string> sentences;

    public GameObject barrera;

    void Start ()

    {
        sentences = new Queue<string>();
    }

    public void StartDialogue (Dialogue_Init dialogue)
    {
        animator.SetBool("IsOpen", true);
        nameText.text = dialogue.name;


        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence; 
    }

    void EndDialogue()
    {
        Debug.Log("End of conversation");
        {
            animator.SetBool("IsOpen", false);
        }
        Destroy(FindObjectOfType<Deteccion_init_trigger>());
        barrera.SetActive(false); 

    }
}

