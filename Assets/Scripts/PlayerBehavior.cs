using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{

    public int hp = 100;
    private int attackPower = 10;
    public GameObject bottle;
    private GameObject b;
    public void ThrowBottle()
    {
        b = Instantiate(bottle, transform, false);
        b.transform.SetParent(null);
        b.GetComponent<Rigidbody>().velocity += transform.TransformDirection(0, 0, 25);
    }

    public void TakeDamage()
    {
        hp -= 10;
        if (hp == 0)
        {
            Dead();
        }
    }

    public void Dead()
    {
        gameObject.GetComponent<Material>().color = Color.red;
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
            ThrowBottle();  

        if(Input.GetKeyDown(KeyCode.Q))
            TakeDamage();

        var screen = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y, 13.5f));
        transform.LookAt(screen);        
        Debug.DrawLine(transform.position, screen, Color.red);       
    }

    
}
