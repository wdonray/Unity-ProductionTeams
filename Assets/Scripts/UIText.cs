using UnityEngine;
using UnityEngine.UI;

public class UIText : MonoBehaviour
{
    private int _countTest;

    public float Timer;

    public Text TimeText, MinionCount;

    // Update is called once per frame
    private void Update()
    {
        Timer += Time.deltaTime;

        var min = Mathf.FloorToInt(Timer / 60f);

        var sec = Mathf.FloorToInt(Timer - min * 60);

        var niceTime = string.Format("{0:00}:{1:00}", min, sec);

        _countTest = GameObject.FindGameObjectWithTag("Spawner").GetComponent<EnemySpawner>().TheCops.Count;

        TimeText.text = "Time: " + niceTime;

        MinionCount.text = "Cops Alive: " + _countTest.ToString();
    }
}