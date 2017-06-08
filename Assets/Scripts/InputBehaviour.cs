using UnityEngine;

public class InputBehaviour : MonoBehaviour
{
    private float _jumpTimer = 1;

    public Animator ani;
    private Vector3 currentPos, previousPos;

    private Rigidbody rb;
    //public MinionCop MinionTest;

    [Range(1, 10)] public int Speed;

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
        rb = gameObject.GetComponent<Rigidbody>();
        currentPos = transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        if (IsMoveleft)
            transform.position += new Vector3(-0.1f, 0, 0) * Speed;
        if (IsMoveup)
            transform.position += new Vector3(0, 0, .1f) * Speed;
        if (IsMovedown)
            transform.position += new Vector3(0, 0, -.1f) * Speed;
        if (IsMoveright)
            transform.position += new Vector3(.1f, 0, 0) * Speed;
        if (IsJump)
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(0, 200, 0));
            _jumpTimer = 1f;
        }
        previousPos = currentPos;
        currentPos = transform.position;
        ani.SetFloat("speed", (currentPos - previousPos).magnitude);
        _jumpTimer -= Time.deltaTime;
        //MinionTest = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyBehavior>().Minion;
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    MinionTest.TakeDamage(3);
        //}
    }
}