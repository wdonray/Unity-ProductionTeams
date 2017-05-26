using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputBehaviour : MonoBehaviour
{
    [Range(1, 10)]
    public int Speed;
    private float _jumpTimer = 1;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
            this.transform.position += new Vector3(-0.1f, 0, 0) * Speed;
        if (Input.GetKey(KeyCode.W))
            this.transform.position += new Vector3(0, 0, .1f)* Speed;
        if (Input.GetKey(KeyCode.S))
            transform.position += new Vector3(0, 0, -.1f) * Speed;
        if (Input.GetKey(KeyCode.D))
            this.transform.position += new Vector3(.1f, 0, 0) * Speed;
        if (Input.GetKeyDown(KeyCode.Space) && _jumpTimer < .5f)
        {
            this.GetComponent<Rigidbody>().AddForce(new Vector3(0, 200, 0));
            _jumpTimer = 1f;
        }
        if (Input.GetKey(KeyCode.Escape))
            Application.Quit();
        _jumpTimer -= Time.deltaTime;
    }
}
