using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSpawner : MonoBehaviour
{

    public float timer = 30.0f;
    public GameObject pickup;
    private bool pickedUp;

	// Use this for initialization
	void Start ()
	{
	    
	}
	
	// Update is called once per frame
	void Update ()
	{
        timer -= 0.1f;
	    if (timer <= 0)
	    {
	        Instantiate(pickup, transform);
	        timer = 30.0f;
	    }
	}
}
