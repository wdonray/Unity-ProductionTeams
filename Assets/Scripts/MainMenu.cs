using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Image BackImage;
    public Text MiddleText;

    private void Start()
    {
        MiddleText.text = "WELCOME TO ___________";
        Time.timeScale = 1;
        StartCoroutine(ColorPicker());
    }

    public void QuitGame()
    {
        MiddleText.text = "Sad To See You Go";
        StartCoroutine(Exit());
    }

    public void StartGame()
    {
        MiddleText.text = "Starting in 3...";
        StartCoroutine(Load());
    }

    public void Controls()
    {
        MiddleText.text = "Left Click: Shoots " +
                          "\n\nW,A,S,D: Moves" +
                          "\n\nESC: Pause";
    }

    public void Credits()
    {
        MiddleText.text = "Programmers:\n Donray Williams\n Reginald Reed " +
                          "\n\nArtist:\n Michael Muguira\n Shane Clarius\n Wedge Denaille";
    }

    public IEnumerator ColorPicker()
    {
        var newColor = new Color(Random.value, Random.value,
            Random.value, 1.0f);
        BackImage.color = newColor;
        yield return new WaitForSeconds(2);
        yield return StartCoroutine(ColorPicker());
    }

    public IEnumerator Load()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("0.Donray");
    }

    public IEnumerator Exit()
    {
        yield return new WaitForSeconds(2);
        Application.Quit();
    }
}