using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSpawner : MonoBehaviour
{

    public float timer;
    public GameObject pickup;
    public bool pickedUp;

	// Use this for initialization
	void Start ()
	{
	    timer = 90.0f;
        pickedUp = true;
	}
	
	// Update is called once per frame
	void Update ()
	{
        timer -= 0.1f;
	    if (pickedUp == true && timer <= 0)
	    {
	        Instantiate(pickup, transform);
	        pickedUp = false;
	    }
	}
}
