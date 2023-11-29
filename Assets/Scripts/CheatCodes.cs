using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CheatCodes : MonoBehaviour
{

    public TMP_InputField CheatCodeInput;

    public string[] Cheat_Codes = {"Sød Kat", "Din Mor", "Heil Hitler"};

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Redeem()
    {
        GameObject RedeemBTN = GameObject.Find("CheatCodeRedeem");
        Image img = RedeemBTN.GetComponent<Image>();

        int RightCode = 0;

        for (int i = 0; i < Cheat_Codes.Length; i++)
        {
            if (CheatCodeInput.text.ToLower() == Cheat_Codes[i].ToLower())
            {
                RightCode++;
            }
        }

        if (RightCode > 0)
        {
            img.color = Color.green;
        }
        else
        {
            img.color = Color.red;

            GameObject[] Hitler = GameObject.FindGameObjectsWithTag("Hitler");

            for (int i = 0;i < Hitler.Length;i++)
            {
                EnemyAI EnemyScript = Hitler[i].GetComponent<EnemyAI>();

                EnemyScript.defaultattackspeed = 0.1f;
                EnemyScript.chaseSpeed = 0.01f;
            }

            GameObject[] MaoZedong = GameObject.FindGameObjectsWithTag("MaoZedong");

            for (int i = 0; i < MaoZedong.Length; i++)
            {
                MaoZedongScript MaoZedongEnemyScript = MaoZedong[i].GetComponent<MaoZedongScript>();

                MaoZedongEnemyScript.defaultattackspeed = 0.1f;
                MaoZedongEnemyScript.chaseSpeed = 0.01f;
            }
        }
    }
}
