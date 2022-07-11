using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int defense;
    public int maxHealth;
    public int health;
    public int mana;
    public int maxMana;
    public int damage;
    public int critChance;
    public int critRate;

    void Start()
    {
        health = maxHealth;
        mana = maxMana;
    }
}
