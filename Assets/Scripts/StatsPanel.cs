using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsPanel : MonoBehaviour
{
    public Text health;
    public Text mana;
    public Text defense;
    public Text damage;
    public Text critChance;
    public Text critRate;

    public Text levelPoints;
    private Player player;

    private PlayerStats stats;
    void Start()
    {
        player = FindObjectOfType<Player>();
        stats = FindObjectOfType<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        health.text = stats.maxHealth.ToString();
        mana.text = stats.maxMana.ToString();
        defense.text = stats.defense.ToString();
        damage.text = stats.damage.ToString();
        critChance.text = stats.critChance.ToString();
        critRate.text = stats.critRate.ToString();
        levelPoints.text = player.levelPointsInt.ToString();
    }

    public void Open()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Close()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
}
