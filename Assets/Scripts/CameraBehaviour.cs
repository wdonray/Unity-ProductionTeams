using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    public GameObject Player, Starter;

    private bool test = true;
    private Vector3 _offset;
	// Use this for initialization
	void Start ()
	{
	    _offset = transform.position - Player.transform.position;
        StartCoroutine(Scene());
    }
	
	// Update is called once per frame
	void Update ()
	{
        if (test == false)
            transform.position = Player.transform.position + _offset;
    }

    public IEnumerator Scene()
    {
        //transform.position = Starter.transform.position + _offset;
        transform.position = new Vector3(Starter.transform.position.x, Starter.transform.position.y, 
            Starter.transform.position.z - 45) + _offset;
        yield return new WaitForSeconds(3);
        test = false;
    }
      
}
