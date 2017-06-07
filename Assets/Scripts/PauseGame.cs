using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    public Transform Canvas;
    public GameObject Player;
    public Transform controlsMenu;
    public Transform pauseMenu;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }
    public void Pause()
    {
        Player.GetComponent<InputBehaviour>();
        if (Canvas.gameObject.activeInHierarchy == false)
        {
            if (pauseMenu.gameObject.activeInHierarchy == false)
            {
                pauseMenu.gameObject.SetActive(true);
                controlsMenu.gameObject.SetActive(false);
            }
            Time.timeScale = 0;
            Player.SetActive(false);
            Canvas.gameObject.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            Player.SetActive(true);
            Canvas.gameObject.SetActive(false);
        }
    }
    public void Exit()
    {
        SceneManager.LoadScene("10.MainMenu");
    }

    public void Controls(bool open)
    {
        if (open)
        {
            controlsMenu.gameObject.SetActive(true);
            pauseMenu.gameObject.SetActive(false);
        }
        if (!open)
        {
            controlsMenu.gameObject.SetActive(false);
            pauseMenu.gameObject.SetActive(true);
        }
    }
}
