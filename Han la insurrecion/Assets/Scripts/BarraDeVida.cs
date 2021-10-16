using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraDeVida : MonoBehaviour
{
    private Image healthBar;
    public float CurrentHealth;
    private float MaxHealth = 8;
    LiuBangCH Player;
    
    private void Start()
    {
        healthBar = GetComponent<Image>();
        Player = FindObjectOfType<LiuBangCH>();
    }

    private void Update()
    {
        CurrentHealth = Player.health;
        healthBar.fillAmount = CurrentHealth / MaxHealth;
    }

}
