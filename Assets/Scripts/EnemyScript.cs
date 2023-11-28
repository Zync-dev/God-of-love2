using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform player;
    public float stopFollowingDistance = 10f;
    public float chaseSpeed = 2f;
    public float stoppingDistance = 2f;

    public float attackspeed = 2f;
    public GameObject SiegHeil;
    public GameObject HitlerWeapon;

    public GameObject HitlerHeil;
    public GameObject HitlerNoHeil;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        PlayerHealth PlayerHealth = player.gameObject.GetComponent<PlayerHealth>();

        if (distanceToPlayer <= stopFollowingDistance && distanceToPlayer > stoppingDistance )
        {
            Vector2 moveDirection = (player.position - transform.position).normalized * chaseSpeed;
            transform.Translate(moveDirection);

        }
        else if (distanceToPlayer <= stoppingDistance + 0.5f && PlayerHealth.isPlayerDead != true)
        {
            attackspeed -= Time.deltaTime;

            if (attackspeed >= 0.25 && attackspeed <= 0.35)
            {
                SiegHeil.SetActive(false);
                HitlerHeil.SetActive(false);
                HitlerNoHeil.SetActive(true);
            }
            if (attackspeed <= 0)
            {
                EnemyAttack();
                attackspeed = 2f;
            }
        }
    }

    public void EnemyAttack()
    {   
        SiegHeil.SetActive(true);
        HitlerHeil.SetActive(true);
        HitlerNoHeil.SetActive(false);

        var Hagekors = Object.Instantiate(HitlerWeapon);
        Hagekors.transform.position = this.transform.position;
    }
}
