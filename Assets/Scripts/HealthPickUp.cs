using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour {


    private GameObject spawner;
    public void Start()
    {
        spawner = GameObject.FindGameObjectWithTag("HPS");
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerBehavior>().PlayerHealth += 15;
            Destroy(gameObject);
            spawner.GetComponent<PickUpSpawner>().pickedUp = true;
            spawner.GetComponent<PickUpSpawner>().timer = 90.0f;
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}
