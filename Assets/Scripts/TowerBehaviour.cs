using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TowerBehaviour : MonoBehaviour
{
    public Tower ATower;

    public Text TowerHp;

    // Use this for initialization
    private void Start()
    {
        ATower = ScriptableObject.CreateInstance<Tower>();
        TowerHp = GameObject.FindGameObjectWithTag("TowerHP").GetComponent<Text>();
    }

    private void Update()
    {
        TowerHp.text = ATower.Health.ToString();
        if (ATower.Health > 0) return;
        StartCoroutine(Load(2, "10.MainMenu"));

    }
    IEnumerator Load(int delay, string load)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(load);
    }
}