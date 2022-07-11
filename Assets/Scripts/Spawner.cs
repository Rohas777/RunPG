using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] variants;
    public GameObject variantGood;

    private float timeBtwSpawn;
    public float startTimeBtwSpawn;
    public float decreaseTime;
    public float minTime;
    public float chestSpawnChance;

    public float enemyHealth;
    public float increaseHealth;
    public float enemyDamage;
    public float increaseDamage;
    public float exp;
    public float increaseExp;

    private void Update()
    {
        enemyDamage += Time.deltaTime * increaseDamage;
        enemyHealth += Time.deltaTime * increaseHealth;
        exp += Time.deltaTime * increaseExp;

        if (timeBtwSpawn <= 0)
        {
            int rand = Random.Range(0, variants.Length);
            if (Random.Range(0, 100) >= (100 - chestSpawnChance))
            {
                Instantiate(variantGood, transform.position, Quaternion.identity);  
            }
            else
            {
                Instantiate(variants[rand], transform.position, Quaternion.identity);
            }
            
            timeBtwSpawn = startTimeBtwSpawn;
            if (startTimeBtwSpawn > minTime)
            {
                startTimeBtwSpawn -= decreaseTime;
            }
        }
        else
        {
            timeBtwSpawn -= Time.deltaTime;
        }
    }
}
