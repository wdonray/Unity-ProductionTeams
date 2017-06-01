using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [HideInInspector] public bool CurrentlyActive;

    public GameObject MinionCop;

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
                minion.Health = 5;
                minion.Damage = 3;
                spawnTime = Random.Range(20, 26);
            }
            else if (MediumMinion)
            {
                minion.Health = 10;
                minion.Damage = 6;
                spawnTime = Random.Range(15, 21);
                
            }
            else if (HardMinion)
            {
                minion.Health = 20;
                minion.Damage = 10;
                spawnTime = Random.Range(10, 16);
            }
            else
            {
                minion.Health = 30;
                minion.Damage = 15;
                spawnTime = 5;
            }
            Debug.Log(spawnTime);
            yield return new WaitForSeconds(spawnTime);
        }
    }
}