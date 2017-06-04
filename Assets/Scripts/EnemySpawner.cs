using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    [HideInInspector] public bool CurrentlyActive;

    public GameObject MinionCop;

    public Text Test;

    public List<GameObject> TheCops;

    public bool EasyMinion
    {
        get { return Time.time < 120; }
    }

    public bool MediumMinion
    {
        get { return Time.time < 420; }
    }

    public bool HardMinion
    {
        get { return Time.time < 620; }
    }

    private void Start()
    {
        TheCops = new List<GameObject>();
        CurrentlyActive = true;
        StartCoroutine(Spawner());
    }

    private IEnumerator Spawner()
    {
        while (CurrentlyActive)
        {
            var go = Instantiate(MinionCop);
            var spawnTime = 1;
            TheCops.Add(go);
            go.transform.position = transform.position;
            var minion = go.GetComponent<EnemyBehavior>().Minion;

            if (EasyMinion)
            {
                minion.CopHealth = 5;
                minion.CopDamage = 3;
                spawnTime = Random.Range(20, 26);
                if (spawnTime == 21)
                    go.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
                Test.text = "Spawning: Easy Cops";
            }
            else if (MediumMinion)
            {
                minion.CopHealth = 10;
                minion.CopDamage = 6;
                spawnTime = Random.Range(15, 21);
                if (spawnTime == 16)
                    go.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
                Test.text = "Spawning: Meduim Cops";
            }
            else if (HardMinion)
            {
                minion.CopHealth = 20;
                minion.CopDamage = 10;
                spawnTime = Random.Range(10, 16);
                if (spawnTime == 11)
                    go.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
                Test.text = "Spawning: Hard Cops";
            }
            else
            {
                minion.CopHealth = 30;
                minion.CopDamage = 15;
                spawnTime = 5;
                Test.text = "Wow why are you still playing";
            }
            Debug.Log(spawnTime);
            yield return new WaitForSeconds(spawnTime);
        }
    }
}