using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour {

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerBehavior>().PlayerHealth += 10;
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}
