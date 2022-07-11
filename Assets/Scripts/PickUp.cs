using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public float playerDist;

    private Transform playerPos;
    private Rigidbody2D rb;
    private CapsuleCollider2D capsuleCollider;

    void Start()
    {
        playerPos = FindObjectOfType<Player>().GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        playerDist = transform.position.x - playerPos.position.x;
        if (playerDist <= 1f)
        {
            rb.gravityScale = 0;
            capsuleCollider.isTrigger = true;
        }
        
    }
}
