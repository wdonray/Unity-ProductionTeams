using UnityEngine;

public class BubbaInputBehaviour : MonoBehaviour
{
    public Animator ani;

    private float h;
    private Vector3 movement;
    public int Speed;
    private float v;

    private void Start()
    {
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        movement = new Vector3(h, 0, v);
        transform.localPosition += movement * Speed * Time.deltaTime;
        ani.SetFloat("speed", movement.magnitude);
    }
}