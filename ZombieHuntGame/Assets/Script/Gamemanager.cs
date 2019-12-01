 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Gamemanager : MonoBehaviour
{
    public Button button;
    public Button button1;
    public Button button2;
    public Button restartButton;

    public bool pressed = false;
    public Button power;

    public int curent;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Quit();
        }
        if (pressed == false)
        {
            power.enabled = true;
        }
        if (pressed == true)
        {
            power.image.enabled = false;
        }
        
    }

    public void pause()
    {
        Time.timeScale = 0;
        button.image.enabled = false;
        button1.image.enabled = false;
        button2.image.enabled = false;
    }

    public void Unpause()
    {
        Time.timeScale = 1;
        button.image.enabled = true;
        button1.image.enabled = true;
        button2.image.enabled = true;
    }

    public void Quit()
    {
        Application.Quit();   
    }

    public void Restart()
    {
        curent = SceneManager.GetActiveScene().buildIndex;
        Time.timeScale = 1;
        SceneManager.LoadScene(curent);
       
    }
}
