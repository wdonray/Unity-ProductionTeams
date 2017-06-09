using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour
{
    public Transform ControlsMenu;
    public Transform PauseMenu;
    public GameObject Player;

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
        if (open)
        {
            ControlsMenu.gameObject.SetActive(true);
            PauseMenu.gameObject.SetActive(false);
        }
        else
        {
            ControlsMenu.gameObject.SetActive(false);
            PauseMenu.gameObject.SetActive(true);
        }
    }
}