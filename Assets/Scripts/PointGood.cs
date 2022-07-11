using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointGood : MonoBehaviour
{
    public GameObject[] chest;
    private Spawner spawner;
    private void Start()
    {
        spawner = FindObjectOfType<Spawner>();
        Instantiate(chest[Random.Range(0, chest.Length)], transform.position, transform.rotation);
    }
}
