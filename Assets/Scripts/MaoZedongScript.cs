using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MaoZedongScript : MonoBehaviour
{
    public Transform player;
    public float stopFollowingDistance = 10f;
    public float chaseSpeed = 2f;
    public float stoppingDistance = 2f;

    public float defaultattackspeed = 1f;
    float attackspeed = 1f;

    public GameObject MaoZedongWeapon;

    public GameObject MaoZedongThrow;
    public GameObject MaoZedongNoThrow;

    AudioSource SiegHeilAudio;

    public float EnemyHealth = 100f;

    public Slider EnemyHealthBar;
    public TMP_Text EnemyHealthTXT;

    public GameObject DamageText;

    public GameObject EnemyHitParticle;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        SiegHeilAudio = this.gameObject.GetComponent<AudioSource>();
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
                MaoZedongNoThrow.SetActive(true);
                MaoZedongThrow.SetActive(false);
                //SiegHeil.SetActive(false);
                //HitlerHeil.SetActive(false);
                //HitlerNoHeil.SetActive(true);
            }
            if (attackspeed <= 0)
            {
                EnemyAttack();
                attackspeed = defaultattackspeed;
            }
        }
    }

    public void EnemyAttack()
    {
        MaoZedongNoThrow.SetActive(false);
        MaoZedongThrow.SetActive(true);
        //SiegHeil.SetActive(true);
        //HitlerHeil.SetActive(true);
        //HitlerNoHeil.SetActive(false);

        SiegHeilAudio.Play();
        var Weapon = Object.Instantiate(MaoZedongWeapon);
        Weapon.transform.position = this.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerProjectile")
        {

            var particleSystem = Instantiate(EnemyHitParticle);
            ParticleSystem ParticleSystemComponent = particleSystem.GetComponent<ParticleSystem>();
            particleSystem.transform.position = this.transform.position;
            ParticleSystemComponent.Play();

            EnemyHealth -= 25f;

            EnemyHealthBar.value = EnemyHealth;
            EnemyHealthTXT.text = $"{EnemyHealth}/150";

            SpawnDamageText();

            Destroy(collision.gameObject);
        }

        if(EnemyHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void SpawnDamageText()
    {
        GameObject DmgTXT = Instantiate(DamageText);

        DmgTXT.transform.position = new Vector3(this.transform.position.x + Random.Range(0, 1), this.transform.position.y + Random.Range(0, 1), 1f);
    }
}
