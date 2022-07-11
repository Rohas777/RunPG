using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    public Enemy[] enemies;
    private Spawner spawner;
    private void Start()
    {
        spawner = FindObjectOfType<Spawner>();
        Instantiate(enemies[Random.Range(0, enemies.Length)], transform.position, transform.rotation);
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].health = Mathf.RoundToInt(enemies[i].health + spawner.enemyHealth);
            enemies[i].damage = Mathf.RoundToInt(enemies[i].damage + spawner.enemyDamage);
            enemies[i].exp = Mathf.RoundToInt(enemies[i].exp + spawner.exp);
        }
    }
}
