using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    private AudioSource _backSound;
    public Image BackImage;
    public Text MiddleText;
    public AudioClip MusicClip;
    public Slider MySlider;

    private void Start()
    {
        _backSound = GetComponent<AudioSource>();
        MiddleText.resizeTextForBestFit = true;
        MiddleText.text = "Welcome To King of The Booze";
        Time.timeScale = 1;
        StartCoroutine(ColorPicker());
        _backSound.clip = MusicClip;
        _backSound.Play();
    }

    public void QuitGame()
    {
        MiddleText.resizeTextForBestFit = true;
        MiddleText.text = "Sad To See You Go";
        StartCoroutine(Exit());
    }

    public void StartGame()
    {
        MiddleText.resizeTextForBestFit = true;
        MiddleText.text = "Starting in 3...";
        StartCoroutine(Load());
    }

    public void Controls()
    {
        MiddleText.resizeTextForBestFit = true;
        MiddleText.text = "[Left Click] Shoots " +
                          "\n\n[W,A,S,D] Moves" +
                          "\n\nESC: Pause";
    }

    public void Credits()
    {
        MiddleText.resizeTextForBestFit = false;
        MiddleText.fontSize = 12;
        MiddleText.text = "Programmers:\n <color=red>Donray Williams</color>\n <color=white>Reginald Reed</color> " +
                          "\n\nArtist:\n <color=lightblue>Michael Muguira</color>\n <color=red>Shane Clarius</color>\n <color=white>Wedge Denaille</color>";
    }

    public void Slider(float value)
    {
        _backSound.volume = value;
    }

    public IEnumerator ColorPicker()
    {
        //while (true)
        //{
        //    var newColor = new Color(Random.value, Random.value,
        //        Random.value, 1.0f);
        //    BackImage.color = newColor;
        //    yield return new WaitForSeconds(2);
        //}
        //yield return StartCoroutine(ColorPicker());
        while (true)
        {
            BackImage.CrossFadeAlpha(0, 1, true);
            yield return new WaitForSeconds(.5f);
            BackImage.CrossFadeAlpha(1, 1, true);
            yield return new WaitForSeconds(.5f);
        }
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