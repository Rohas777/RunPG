using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed;
    public float dir;
    public int currentExp;
    public int maxExp;
    public int level;

    private PlayerStats stats;
    private Rigidbody2D rb;
    private Animator anim;
    private Animator camAnim;
    private StatsPanel sp;
    public int levelPointsInt;
    public Image levelUp;
    public DeathMenu deathMenu;

    private void Start()
    {
        sp = FindObjectOfType<StatsPanel>();
        stats = FindObjectOfType<PlayerStats>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        camAnim = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(dir * speed, rb.velocity.y);

        if (currentExp >= maxExp)
        {
            currentExp -= maxExp;
            maxExp *= 2;
            level++;
            stats.health = stats.maxHealth;
            stats.mana = stats.maxMana;
            levelPointsInt++;
        }
        GameObject.FindGameObjectWithTag("LevelOrb").GetComponentInChildren<Text>().text = level.ToString();

        if (levelPointsInt > 0) levelUp.gameObject.SetActive(true);
        else levelUp.gameObject.SetActive(false);

        if (stats.health <= 0) Death();
    }
    public void Death()
    {
        deathMenu.gameObject.SetActive(true);
        Destroy(gameObject);
        Time.timeScale = 0f;
    }

    public void TakeDamage(int damage)
    {
        camAnim.SetTrigger("shake");
        if (damage > stats.defense)
        {
            damage -= stats.defense;
            stats.health -= damage;
        }
        
    }

    public void HealthUp()
    {
        if (levelPointsInt > 0)
        {
            stats.maxHealth += 5;
            levelPointsInt--;
        }
    }
    public void ManaUp()
    {
        if (levelPointsInt > 0)
        {
            stats.maxMana += 5;
            levelPointsInt--;
        }
    }
    public void DefenseUp()
    {
        if (levelPointsInt > 0)
        {
            stats.defense += 1;
            levelPointsInt--;
        }
    }
    public void DamageUp()
    {
        if (levelPointsInt > 0)
        {
            stats.damage += 1;
            levelPointsInt--;
        }
    }
    public void CritChanceUp()
    {
        if (levelPointsInt > 0)
        {
            stats.critChance += 1;
            levelPointsInt--;
        }
    }
    public void CritRateUp()
    {
        if (levelPointsInt > 0)
        {
            stats.critRate += 5;
            levelPointsInt--;
        }
    }
}
