using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void RestartBTN()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void MainMenuBTN()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
