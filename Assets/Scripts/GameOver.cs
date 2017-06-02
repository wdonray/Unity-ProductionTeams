using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class GameOver : MonoBehaviour
{
    [HideInInspector] public PlayerBehavior Player;
    public int RestartDelay = 5;

    private void Start()
    {
        Player = GetComponent<PlayerBehavior>();
    }

    private void Update()
    {
        if (Player.PlayerHealth > 0) return;
        StartCoroutine(Load(RestartDelay, "0.Donray"));
    }
    IEnumerator Load(int delay, string load)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(load);
    }
}