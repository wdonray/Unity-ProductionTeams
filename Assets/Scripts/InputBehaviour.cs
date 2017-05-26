using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputBehaviour : MonoBehaviour
{
    private float jumpTimer = 1;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
            this.transform.position += new Vector3(-0.1f, 0, 0);
        if (Input.GetKey(KeyCode.W))
            this.transform.position += new Vector3(0, 0, .1f);
        if (Input.GetKey(KeyCode.S))
            transform.position += new Vector3(0, 0, -.1f);
        if (Input.GetKey(KeyCode.D))
            this.transform.position += new Vector3(.1f, 0, 0);
        if (Input.GetKeyDown(KeyCode.Space) && jumpTimer < .5f)
        {
            this.GetComponent<Rigidbody>().AddForce(new Vector3(0, 200, 0));
            jumpTimer = 1f;
        }
        if (Input.GetKey(KeyCode.Escape))
            Application.Quit();
        jumpTimer -= Time.deltaTime;
    }
}
