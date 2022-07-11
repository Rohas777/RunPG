using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerPos;
    public Transform variantPos;
    public Transform variantGoodPos;
    public Transform spawnerPos;
    private Vector3 variantOffset;
    private Vector3 variantGoodOffset;
    private float startPlayerPos;

    private void Start()
    {
        variantOffset = variantPos.position - transform.position;
        variantGoodOffset = variantGoodPos.position - transform.position;
        startPlayerPos = playerPos.position.x;
    }
    private void FixedUpdate()
    {
        variantPos.position = new Vector3(transform.position.x + variantOffset.x, 0f, 0f);
        variantGoodPos.position = new Vector3(transform.position.x + variantGoodOffset.x, 0f, 0f);
        spawnerPos.position = new Vector3(transform.position.x, 0f, 0f);

        if (playerPos.position.x > startPlayerPos)
        {
            transform.position = new Vector3(playerPos.position.x - startPlayerPos, transform.position.y, transform.position.z);
        }
    }
}
