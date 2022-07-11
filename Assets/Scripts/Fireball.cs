using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float startTimeBtwShots;
    private float timeBtwShots;
    public int cost;

    private PlayerStats stats;
    public GameObject fireball;
    public Buttons fireballButton;
    public Transform shotPoint;

    private void Start()
    {
        stats = FindObjectOfType<PlayerStats>();
    }

    private void FixedUpdate()
    {
        if (timeBtwShots <= 0 && stats.mana >= cost)
        {
            fireballButton.img.sprite = fireballButton.sprite;
            if (fireballButton.isAttackClicked == true)
            {
                Instantiate(fireball, shotPoint.position, transform.rotation);
                stats.mana -= cost;
                timeBtwShots = startTimeBtwShots;
            }
        } else
        {
            fireballButton.img.sprite = fireballButton.spriteDisactive;
            timeBtwShots -= Time.fixedDeltaTime;
        }
    }
}
