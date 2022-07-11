using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Player player;
    private PlayerStats stats;
    public Image healthBar;
    public Image manaBar;
    public Image levelBar;
    public float fillHealth;
    public float fillMana;
    public float fillLevel;

    private void Start()
    {
        player = FindObjectOfType<Player>();
        stats = FindObjectOfType<PlayerStats>();
        fillHealth = stats.maxHealth;
        fillMana = stats.maxMana;
        fillLevel = player.currentExp;
    }

    private void Update()
    {
        fillHealth = (float)stats.health / (float)stats.maxHealth;
        fillMana = (float)stats.mana / (float)stats.maxMana;
        fillLevel = (float)player.currentExp / (float)player.maxExp;
        healthBar.fillAmount = fillHealth;
        manaBar.fillAmount = fillMana;
        levelBar.fillAmount = fillLevel;
    }
}
