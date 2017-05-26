using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{

    private int hp;
    private int attackPower;
    private float speed;
    public GameObject bottle;
    private GameObject b;
    public void ThrowBottle()
    {
        b = Instantiate(bottle, transform, false);
        b.transform.SetParent(null);
        b.GetComponent<Rigidbody>().velocity += transform.TransformDirection(0, 0, 25);

    }

    public void Update()
    {

        if (Input.GetMouseButtonDown(0))
            ThrowBottle();

        b.transform.Rotate(0, 90 * Time.deltaTime, 0);

    }


}
