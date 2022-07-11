using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public GameObject[] loot;
    public GameObject chestOpen;
    public float dropImpulse;
    private int count;

    private void Awake()
    {
        count = Random.Range(1, 2);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Instantiate(chestOpen, transform.position, Quaternion.identity);
            Destroy(gameObject);
            for (int i = 0; i < count; i++)
            {
                dropImpulse = Random.Range(0.5f, 2.5f);
                GameObject drop = Instantiate(loot[Random.Range(0, loot.Length)], transform.position, Quaternion.identity);
                drop.GetComponent<Rigidbody2D>().AddForce(Vector2.right * dropImpulse, ForceMode2D.Impulse);
            }

        }
    }
}
