using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject minionCop;

    public bool currentlyActive;

    public List<GameObject> theCops;
    private void Start()
    {
        theCops = new List<GameObject>();
        currentlyActive = true;
        StartCoroutine(Spawner());
    }
    IEnumerator Spawner()
    {
        while (currentlyActive)
        {
            GameObject go = Instantiate<GameObject>(minionCop);
            theCops.Add(go);
            go.transform.position = this.transform.position;

            var SpawnTime = Random.Range(2, 6);

            if (theCops.Count > 10)
                SpawnTime = SpawnTime * 2;
            else
                SpawnTime = Random.Range(2, 6); 

            Debug.Log(SpawnTime);
            yield return new WaitForSeconds(SpawnTime);
        }
    }
}
