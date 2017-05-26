using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    public GameObject Player;

    private Vector3 _offset;
	// Use this for initialization
	void Start ()
	{
	    _offset = transform.position - Player.transform.position;
	}
	
	// Update is called once per frame
	void Update ()
	{
	    transform.position = Player.transform.position + _offset;
	}
}
