using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPickUp : MonoBehaviour {

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<BubbaInputBehaviour>().Speed += 2;
              Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
