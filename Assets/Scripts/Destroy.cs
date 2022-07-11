using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    private Transform player;
    private void Start()
    {
        player = GameObject.FindObjectOfType<Player>().GetComponent<Transform>();
    }

    void Update()
    {
        if (player.position.x > transform.position.x + 15)
        {
            Destroy(gameObject);
        }
    }
}
