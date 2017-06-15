using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class EnemySpawner : MonoBehaviour
{
    [HideInInspector] public bool CurrentlyActive;

    public GameObject MinionCop;

    public Text SpawnText;

    public static List<GameObject> TheCops;

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

    private GameObject Filler;

    private void Start()
    {
        TheCops = new List<GameObject>();
        TheCops.Add(Filler);
        CurrentlyActive = true;
        StartCoroutine(Spawner());
    }

    private IEnumerator Spawner()
    {
        while (CurrentlyActive)
        {
            var go = Instantiate(MinionCop);
            go.GetComponent<NavMeshAgent>().Warp(this.transform.position);
            var spawnTime = 1;
            TheCops.Add(go);
            var minion = go.GetComponent<EnemyBehavior>().Minion;
            
            if (EasyMinion)
            {
                minion.CopHealth = 50;
                minion.CopDamage = 5;
                spawnTime = Random.Range(10, 15);
                if (spawnTime == 11)
                {
                    minion.CopHealth = 55;
                    minion.CopDamage = 15;
                    go.transform.localScale = new Vector3(9, 9, 9);
                }
                SpawnText.text = "Spawning: Easy Cops";
            }
            else if (MediumMinion)
            {
                minion.CopHealth = 70;
                minion.CopDamage = 15;
                spawnTime = Random.Range(5, 11);
                if (spawnTime == 6)
                {
                    minion.CopHealth = 80;
                    minion.CopDamage = 25;
                    go.transform.localScale = new Vector3(9, 9, 9);
                }
                SpawnText.text = "Spawning: Meduim Cops";
            }
            else if (HardMinion)
            {
                minion.CopHealth = 100;
                minion.CopDamage = 30;
                spawnTime = Random.Range(1, 6);
                if (spawnTime == 1)
                {
                    minion.CopHealth = 145;
                    minion.CopDamage = 45;
                    go.transform.localScale = new Vector3(9, 9, 9);
                }
                SpawnText.text = "Spawning: Hard Cops";
            }
            else
            {
                minion.CopHealth = 250;
                minion.CopDamage = 150;
                spawnTime = 1;
                SpawnText.text = "Wow why are you still playing";
            }
            yield return new WaitForSeconds(spawnTime);
        }
    }
}