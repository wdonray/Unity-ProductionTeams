using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject MinionCop;

    public List<GameObject> TheCops;

    [HideInInspector]
    public bool CurrentlyActive;

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
            TheCops.Add(go);
            go.transform.position = transform.position;
            var Minion = go.GetComponent<EnemyBehavior>().Minion;

            Minion.Health = 5;
            Minion.Damage = 3;

            var spawnTime = Random.Range(2, 6);

            Debug.Log(spawnTime);
            yield return new WaitForSeconds(spawnTime);
        }
    }
}