using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{

    AudioSource[] audiosource;

    public GameObject InformationPanel;

    private void Start()
    {
        audiosource = this.GetComponents<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            SceneManager.LoadScene("MainScene");
        }
    }

    public void RestartBTN()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void MainMenuBTN()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void PlayBTN()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void QuitGameBTN()
    {
        audiosource[0].Play();
        audiosource[1].Play();

        Application.OpenURL("https://www.youtube.com/watch?v=QDia3e12czc");
    }

    public void InformationPanelOpen()
    {
        InformationPanel.SetActive(true);
    }
}
