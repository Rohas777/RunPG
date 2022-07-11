using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public int damage;
    public int exp;
    public float speed;
    public float forceImpulse;

    public float startTimeBtwAttack;
    private float timeBtwAttack;
    public float startStopTime;
    private float stopTime;
    public float normalSpeed;

    public float startTimeBtwShots;
    private float timeBtwShots;

    private Player player;
    private PlayerStats stats;
    private Rigidbody2D rb;
    public GameObject deathEffect;
    public GameObject strike;
    private Animator anim;
    public Transform shotPoint;

    private void Start()
    {
        stats = FindObjectOfType<PlayerStats>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<Player>();
        normalSpeed = speed;
    }

    private void Update()
    {
        timeBtwShots -= Time.fixedDeltaTime;
        if (stopTime <= 0)
        {
            speed = normalSpeed;
        }
        else
        {
            speed = 0;
            stopTime -= Time.deltaTime;
        }
        if(health <= 0)
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
            player.currentExp += exp;
        }

        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
    public void TakeDamage(int damage)
    {
        stopTime = startStopTime;
        health -= damage;
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (timeBtwAttack <= 0)
            {
                anim.SetTrigger("attack");

                timeBtwAttack = startTimeBtwAttack;
            }
            else
            {
                timeBtwAttack -= Time.deltaTime;
            }
        }
    }

    public void OnEnemyAttack()
    {
        player.TakeDamage(damage);
        rb.AddForce(gameObject.transform.right * forceImpulse,ForceMode2D.Impulse);
    }

    public void OnEnemyShoot()
    {
        if (timeBtwShots <= 0)
        {
            Instantiate(strike, shotPoint.position, transform.rotation);
            timeBtwShots = startTimeBtwShots;
        }

    }

}
