using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraBehaviour : MonoBehaviour
{
    public GameObject Player, Starter;

    private bool WaitOverTransition = true;
    private Vector3 _offset;
    public Text info;
	// Use this for initialization
	void Start ()
	{
	    _offset = transform.position - Player.transform.position;
        StartCoroutine(Scene());
    }

    // Update is called once per frame
    void Update()
    {
        if (!WaitOverTransition)
        {
            var b = Player.transform.position + _offset;
            transform.position = Vector3.Lerp(transform.position, b, Time.deltaTime);
            info.CrossFadeAlpha(0, 1, true);
        }
    }

    public IEnumerator Scene()
    {
        transform.position = new Vector3(Starter.transform.position.x,
            Starter.transform.position.y, 
            Starter.transform.position.z - 45) + _offset;
        yield return new WaitForSeconds(3);
        WaitOverTransition = false;
    }
}
