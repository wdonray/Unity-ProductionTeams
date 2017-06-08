using UnityEngine;

public class BubbaInputBehaviour : MonoBehaviour
{
    private float _jumpTimer = 1;

    public Animator ani;


    private Rigidbody rb;
    //public MinionCop MinionTest;

    [Range(1, 10)]
    public int Speed;

    public bool IsMoveleft
    {
        get { return Input.GetKey(KeyCode.A); }
    }

    public bool IsMoveup
    {
        get { return Input.GetKey(KeyCode.W); }
    }

    public bool IsMovedown
    {
        get { return Input.GetKey(KeyCode.S); }
    }

    public bool IsMoveright
    {
        get { return Input.GetKey(KeyCode.D); }
    }

    public bool IsJump
    {
        get { return Input.GetKeyDown(KeyCode.Space) && _jumpTimer < .5f; }
    }

    private void Start()
    {
        ani = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (IsMoveleft)
            rb.velocity += new Vector3(-0.1f, 0, 0) * Time.deltaTime;
        if (IsMoveup)
            rb.velocity += new Vector3(0, 0, .1f) * Time.deltaTime;
        if (IsMovedown)
            rb.velocity += new Vector3(0, 0, -.1f) * Time.deltaTime;
        if (IsMoveright)
            rb.velocity += new Vector3(.1f, 0, 0) * Time.deltaTime;
        if (IsJump)
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(0, 200, 0));
            _jumpTimer = 1f;
        }

        ani.SetFloat("speed", rb.velocity.magnitude);
        _jumpTimer -= Time.deltaTime;
        //MinionTest = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyBehavior>().Minion;
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    MinionTest.TakeDamage(3);
        //}
    }
}