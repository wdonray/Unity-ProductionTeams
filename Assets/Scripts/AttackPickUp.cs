using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPickUp : MonoBehaviour {


    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerBehavior>().bottlePrefab.GetComponent<ProjectileBehavior>().AttackPower += 5;
            Destroy(gameObject);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
