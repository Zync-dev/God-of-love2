using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour
{

    public float health = 100;
    public Slider healthSlider;

    public TMP_Text healthText;

    public float HitlerDamage;
    public float MaoZedongDamage;

    public GameObject DeathScreen;
    public TMP_Text KilledByTXT;

    AudioSource[] DeathMusic;
    AudioSource MusicToPlay;

    public bool isPlayerDead = false;

    public GameObject BombExplotion;

    public GameObject DamageTextPlayer;

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
            SpawnDamageText(HitlerDamage);
        }
        if (collision.tag == "Bombe")
        {
            TakeDamage(MaoZedongDamage);
            Destroy(collision.gameObject);
            KilledByTXT.text = "MAO ZEDONG";
            MusicToPlay = DeathMusic[1];
            SpawnDamageText(MaoZedongDamage);

            var Explotion = Instantiate(BombExplotion);
            Explotion.transform.position = collision.transform.position;

            AudioSource explotionSound = Explotion.GetComponent<AudioSource>();
            explotionSound.Play();
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
        healthText.text = $"{health}/100";
    }

    public void SpawnDamageText(float damage)
    {
        GameObject DmgTXT = Instantiate(DamageTextPlayer);
        TMP_Text DmgTXTObj = DmgTXT.GetComponentInChildren<TMP_Text>();

        DmgTXTObj.text = "-" + damage.ToString("0.##");
        DmgTXT.transform.position = new Vector3(this.transform.position.x + Random.Range(0, 1), this.transform.position.y + Random.Range(0, 1), 1f);
    }
}
