using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerAttack : MonoBehaviour
{

    public GameObject[] activateOnShoot;
    public GameObject[] deactivateOnShoot;

    bool startTimer = false;
    public float cooldown = 2f;

    public GameObject arrowPrefab;
    public float shootForce = 100f;

    public bool ShootRight = true;

    public TMP_Text CooldownText;
    GameObject CooldownTextObj;

    void Start()
    {
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && cooldown == 2f) 
        {
            ShootArrow();
            startTimer = true;
            CooldownTextObj = CooldownText.gameObject;
            CooldownTextObj.SetActive(true);
        }

        if (startTimer) 
        { 
            cooldown -= Time.deltaTime;
        }

        if(cooldown <= 0)
        {
            CooldownTextObj = CooldownText.gameObject;
            CooldownTextObj.SetActive(false);
            startTimer = false;
            cooldown = 2f;
        } else if(cooldown > 0 && cooldown <= 1.0f)
        {
            ResetCharacter();
        }

        CooldownTextObj = CooldownText.gameObject;
        CooldownTextObj.transform.position = new Vector2(this.transform.position.x, this.transform.position.y + 1.3f);

        CooldownText.text = $"{cooldown.ToString("0.##")}s cooldown";
    }

    public void ShootArrow()
    {
        for (int i = 0; i < activateOnShoot.Length; i++)
        {
            activateOnShoot[i].SetActive(true);
        }
        for (int i = 0; i < deactivateOnShoot.Length; i++)
        {
            deactivateOnShoot[i].SetActive(false);
        }

        Shoot();
    }

    public void ResetCharacter()
    {
        for (int i = 0; i < activateOnShoot.Length; i++)
        {
            activateOnShoot[i].SetActive(false);
        }
        for (int i = 0; i < deactivateOnShoot.Length; i++)
        {
            deactivateOnShoot[i].SetActive(true);
        }
    }

    void Shoot()
    {
        GameObject arrow = Instantiate(arrowPrefab, transform.position, transform.rotation);
        Rigidbody2D rb = arrow.GetComponent<Rigidbody2D>();

        if (ShootRight)
        {
            rb.AddForce(transform.right * shootForce, ForceMode2D.Impulse); // Add force to the arrow to make it fly
        } else if (!ShootRight)
        {
            rb.AddForce(-transform.right * shootForce, ForceMode2D.Impulse); // Add force to the arrow to make it fly
        }
    }

    public void FlipShootingDirection(bool right)
    {
        ShootRight = right;
    }
}
