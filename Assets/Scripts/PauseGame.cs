using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour
{
    public Transform ControlsMenu;
    public Transform PauseMenu;
    public GameObject Player;
    public Sprite NormalCan;
    public List<Image> Buttons = new List<Image>();

    private void Start()
    {
        PauseMenu.gameObject.SetActive(false);
        ControlsMenu.gameObject.SetActive(false); 
    }
    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Pause();
    }

    public void Pause()
    {
        foreach(var button in Buttons)
        {
            if(button.sprite != NormalCan)
                button.sprite = NormalCan;
        }
        Player.GetComponent<InputBehaviour>();
        if (PauseMenu.gameObject.activeInHierarchy == false)
        {
            PauseMenu.gameObject.SetActive(true);
            ControlsMenu.gameObject.SetActive(false);
            Time.timeScale = 0;
            Player.SetActive(false);
            PauseMenu.gameObject.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            Player.SetActive(true);
            PauseMenu.gameObject.SetActive(false);
        }
    }

    public void Exit()
    {
        SceneManager.LoadScene("10.MainMenu");
    }

    public void Controls(bool open)
    {
        //Buttons[2].sprite = NormalCan;
        if (open)
        {
            ControlsMenu.gameObject.SetActive(true);
            PauseMenu.gameObject.SetActive(false);
        }
        else
        {
            ControlsMenu.gameObject.SetActive(false);
            PauseMenu.gameObject.SetActive(true);
            //Buttons[3].sprite = NormalCan;
        }
    }
}