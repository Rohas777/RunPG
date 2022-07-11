using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float timeBtwAttack;
    public float startTimeBtwAttack;

    private float speed;
    private Player player;
    private PlayerStats stats;

    public Transform attackPos;
    public LayerMask enemy;
    public float attackRange;
    public Animator anim;
    public Buttons attackButton;

    private void Start()
    {
        stats = FindObjectOfType<PlayerStats>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        speed = player.speed;
    }

    private void Update()
    {
        if (timeBtwAttack <= 0)
        {
            attackButton.img.sprite = attackButton.sprite;

            if (attackButton.isAttackClicked == true)
            {
                player.speed = 0;
                anim.SetBool("isRunning", false);
                anim.SetTrigger("attack");

                timeBtwAttack = startTimeBtwAttack;
            }
            else
            {
                player.speed = speed;
                anim.SetBool("isRunning", true);
            }
        }
        else
        {
            attackButton.img.sprite = attackButton.spriteDisactive;
            timeBtwAttack -= Time.deltaTime;
        }
    }

    public void OnAttack()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPos.position, attackRange, enemy);
        for (int i = 0; i < enemies.Length; i++)
        {
            if(Random.Range(1, 100) > (100 - stats.critChance))
            {
                enemies[i].GetComponent<Enemy>().TakeDamage(stats.damage + stats.critRate);
            }
            else
            {
                enemies[i].GetComponent<Enemy>().TakeDamage(stats.damage);
            }
        }
    }

    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }

}
