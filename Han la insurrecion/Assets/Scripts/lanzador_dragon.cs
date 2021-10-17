using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lanzador_dragon : MonoBehaviour
{

    public GameObject dragon;
    public GameObject counter;

    void Update()
    {
        if (dragon.GetComponent<ataque_dragon>().firstShotTime == counter.GetComponent<TimerCountdown>().secondsLeft)
        {
            dragon.SetActive(true);
            StartCoroutine(destruir());
        }
    }

    IEnumerator destruir()
    {
        yield return new WaitForSeconds(2.5f);
        dragon.SetActive(false);
    }

}
