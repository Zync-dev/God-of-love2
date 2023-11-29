using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaoZedongProjectile : MonoBehaviour
{

    public Transform player;

    public float ProjectileSpeed;

    public Vector2 moveDirection;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        moveDirection = (player.position - transform.position).normalized * ProjectileSpeed;
        print(moveDirection);
    }

    void Update()
    {
        transform.Translate(moveDirection);
    }
}
