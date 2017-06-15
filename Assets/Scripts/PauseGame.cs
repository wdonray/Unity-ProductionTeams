using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour
{
    public Transform ControlsMenu;
    public Transform PauseCanvas;
    public Transform PauseMenu;
    public Transform PauseBackground;
    public GameObject Player;
    public Sprite NormalCan;
    public List<Image> Buttons = new List<Image>();
    Rigidbody playerRigidbody;
    private void Start()
    {
        playerRigidbody = Player.GetComponent<Rigidbody>();
        PauseMenu.gameObject.SetActive(false);
        ControlsMenu.gameObject.SetActive(false); 
    }
    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Pause();
    }
    public bool paused = false;
    public void Pause()
    {
        paused = !paused;
        if (paused)
        {
            playerRigidbody.isKinematic = true;
            PauseMenu.gameObject.SetActive(true);
            PauseCanvas.gameObject.SetActive(true);
            ControlsMenu.gameObject.SetActive(false);
            PauseBackground.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
        else if (!paused)
        {
            Time.timeScale = 1;
            playerRigidbody.isKinematic = false;
            PauseBackground.gameObject.SetActive(false);
            PauseMenu.GetComponentInChildren<TestCigaretteBehaviour>().ClosePack();
        }
    }

    public void Exit()
    {
        SceneManager.LoadScene("10.MainMenu");
    }

    public void Controls(bool open)
    {
        if (open == true)
        {
            //Buttons[2].sprite = NormalCan;
            //Buttons[3].sprite = NormalCan;
            ControlsMenu.gameObject.SetActive(true);
            PauseMenu.gameObject.SetActive(false);
            PauseBackground.gameObject.SetActive(false);
            //Debug.Log("open");
        }
        else if (open == false)
        {
            //Buttons[3].sprite = NormalCan;
            //Buttons[2].sprite = NormalCan;
            PauseMenu.gameObject.SetActive(true);
            ControlsMenu.gameObject.SetActive(false);
            PauseBackground.gameObject.SetActive(true);
            //Debug.Log("closed");
        }
    }
}