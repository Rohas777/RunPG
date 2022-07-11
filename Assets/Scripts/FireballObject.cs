using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballObject : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    public float distance;
    public int damage;
    public string targetTag;
    public bool playerShot;

    public GameObject effect;
    public LayerMask whatIsSloid;

    private Animator camAnim;

    private void Start()
    {
        camAnim = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();
    }

    private void Update()
    {
        lifeTime -= Time.deltaTime;
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.right, distance, whatIsSloid);
        
        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag(targetTag))
            {
                if (playerShot) hitInfo.collider.GetComponent<Enemy>().TakeDamage(damage);
                else if (!playerShot) hitInfo.collider.GetComponent<Player>().TakeDamage(damage);
            }
            Instantiate(effect, transform.position, Quaternion.identity);
            if (playerShot) camAnim.SetTrigger("shake");
            Destroy(gameObject);
        }
        if (playerShot) transform.Translate(Vector2.right * speed * Time.deltaTime);
        else if (!playerShot) transform.Translate(Vector2.left * speed * Time.deltaTime);
        if (lifeTime <= 0) Destroy(gameObject);
    }
}
