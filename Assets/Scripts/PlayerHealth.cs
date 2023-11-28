using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour
{

    public float health = 100;
    public Slider healthSlider;

    public float HitlerDamage;
    public float MaoZedongDamage;

    public GameObject DeathScreen;
    public TMP_Text KilledByTXT;

    AudioSource[] DeathMusic;
    AudioSource MusicToPlay;

    public bool isPlayerDead = false;

    void Start()
    {
        healthSlider.value = health;

        GameObject Camera = GameObject.FindGameObjectWithTag("MainCamera");
        DeathMusic = Camera.GetComponents<AudioSource>();
    }

    void Update()
    {
        if (health <= 0)
        {
            DeathScreen.SetActive(true);

            isPlayerDead = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "HageKors")
        {
            TakeDamage(HitlerDamage);
            Destroy(collision.gameObject);
            KilledByTXT.text = "HITLER";
            MusicToPlay = DeathMusic[0];

        }
        if (collision.tag == "Bombe")
        {
            TakeDamage(MaoZedongDamage);
            Destroy(collision.gameObject);
            KilledByTXT.text = "MAO ZEDONG";
            MusicToPlay = DeathMusic[1];
        }

        if(health <= 0)
        {
            MusicToPlay.Play();
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        healthSlider.value = health;
    }
}
