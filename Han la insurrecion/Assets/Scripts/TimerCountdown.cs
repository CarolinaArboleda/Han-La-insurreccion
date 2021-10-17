using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerCountdown : MonoBehaviour
{

    public GameObject textDisplay;
    public GameObject barrera;
    public GameObject textTrigger;
    public GameObject pickupDragon;

    public int secondsLeft = 45;
    public bool takingAway = false;
    public bool endDialogue = false;


    void Update()
    {
        if (takingAway == false && secondsLeft > 0 && endDialogue)
        {
            StartCoroutine(TimerTake());
        }

        if (secondsLeft <= 0)
        {
            textDisplay.SetActive(false);
            barrera.SetActive(false);
        }

    }

    IEnumerator TimerTake()
    {
        takingAway = true;
        textDisplay.GetComponent<Text>().text = "00:" + secondsLeft;
        barrera.SetActive(true);
        textDisplay.SetActive(true);
        yield return new WaitForSeconds(1);
        secondsLeft -= 1;
        textDisplay.GetComponent<Text>().text = "00:" + secondsLeft;
        takingAway = false;

        if (takingAway == false && secondsLeft <= 0)
        {
            textTrigger.GetComponent<finalizacion_dialogo_dragon_trigger>().TriggerDialogue();
            pickupDragon.SetActive(true);
        }
    }

}
