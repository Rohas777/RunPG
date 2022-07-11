using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PoisonsUse : MonoBehaviour
{
    public float startTimeBtwUse;
    private float timeBtwUse;
    public int countSP;
    public int maxCount;
    public int countHP;

    private PlayerStats stats;
    public Buttons spButton;
    public Buttons hpButton;
    private void Start()
    {
        countSP = int.Parse(spButton.GetComponentInChildren<Text>().text);
        countHP = int.Parse(hpButton.GetComponentInChildren<Text>().text);
        stats = FindObjectOfType<PlayerStats>();
    }
    private void FixedUpdate()
    {
        if (timeBtwUse <= 0 && stats.mana < stats.maxMana && countSP > 0)
        {
            spButton.img.sprite = spButton.sprite;
            if (spButton.isAttackClicked == true)
            {
                stats.mana = stats.maxMana;
                countSP--;
                spButton.GetComponentInChildren<Text>().text = countSP.ToString();
                timeBtwUse = startTimeBtwUse;
            }
        }
        else
        {
            spButton.img.sprite = spButton.spriteDisactive;
            timeBtwUse -= Time.fixedDeltaTime;
        }
        if (timeBtwUse <= 0 && stats.health < stats.maxHealth && countHP > 0)
        {
            hpButton.img.sprite = hpButton.sprite;
            if (hpButton.isAttackClicked == true)
            {
                stats.health = stats.maxHealth;
                countHP--;
                hpButton.GetComponentInChildren<Text>().text = countHP.ToString();
                timeBtwUse = startTimeBtwUse;
            }
        }
        else
        {
            hpButton.img.sprite = hpButton.spriteDisactive;
            timeBtwUse -= Time.fixedDeltaTime;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("HPpoison"))
        {
            if (countHP == maxCount)
            {
                Destroy(collision.gameObject);
            }
            else
            {
                countHP++;
                hpButton.GetComponentInChildren<Text>().text = countHP.ToString();
                Destroy(collision.gameObject);
            }
            
        }
        else if(collision.CompareTag("SPpoison"))
        {
            if (countSP == maxCount)
            {
                Destroy(collision.gameObject);
            }
            else
            {
                countSP++;
                spButton.GetComponentInChildren<Text>().text = countSP.ToString();
                Destroy(collision.gameObject);
            }
        }
    }

}
